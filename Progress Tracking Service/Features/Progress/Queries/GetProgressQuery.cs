using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.Common.BaseHandler;
using ProgressTrackingService.Common.ResultPattern;
using ProgressTrackingService.Features.Progress.Dtos;

namespace ProgressTrackingService.Features.Progress.Queries;

public record GetProgressQuery(long UserId, string? Period, DateTime? StartDate, DateTime? EndDate) : IRequest<RequestResult<ProgressSummaryDto>>;

public class GetProgressQueryHandler : BaseHandler<GetProgressQuery, RequestResult<ProgressSummaryDto>>
{
    private readonly IMapper _mapper;

    public GetProgressQueryHandler(BaseParameters baseParameters, IMapper mapper) : base(baseParameters) => _mapper = mapper;

    public override async Task<RequestResult<ProgressSummaryDto>> Handle(GetProgressQuery request, CancellationToken cancellationToken)
    {
        var endDate = request.EndDate?.ToUniversalTime() ?? DateTime.UtcNow;
        var startDate = request.StartDate?.ToUniversalTime() ?? GetStartDate(request.Period, endDate);
        var workouts = await _context.WorkoutLogs
            .Where(log => log.UserId == request.UserId && log.CompletedAt >= startDate && log.CompletedAt <= endDate)
            .ToListAsync(cancellationToken);
        var statistics = await _context.UserStatisticss.FindAsync([request.UserId], cancellationToken);
        var streak = await _context.Streaks.SingleOrDefaultAsync(item => item.UserId == request.UserId, cancellationToken);

        return RequestResult<ProgressSummaryDto>.Success(new ProgressSummaryDto
        {
            UserId = request.UserId,
            CompletedWorkouts = workouts.Count,
            CaloriesBurned = workouts.Sum(log => log.CaloriesBurned),
            CurrentWeight = statistics?.CurrentWeight,
            Streak = streak is null ? null : _mapper.Map<StreakDto>(streak)
        });
    }

    private static DateTime GetStartDate(string? period, DateTime endDate) => period?.ToLowerInvariant() switch
    {
        "week" => endDate.AddDays(-7),
        "month" => endDate.AddMonths(-1),
        "year" => endDate.AddYears(-1),
        _ => DateTime.MinValue
    };
}
