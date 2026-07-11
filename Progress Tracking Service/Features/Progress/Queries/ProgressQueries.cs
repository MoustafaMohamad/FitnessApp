// using MapsterMapper;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Progress_Tracking_Service.Entities;
// using ProgressTrackingService.Common.BaseHandler;
// using ProgressTrackingService.Common.Enums;
// using ProgressTrackingService.Common.ResultPattern;
// using ProgressTrackingService.Features.Progress.Dtos;

// namespace ProgressTrackingService.Features.Progress.Queries;

// public  record GetProgressQuery(long UserId, string? Period, DateTime? StartDate, DateTime? EndDate) : IRequest<RequestResult<ProgressSummaryDto>>;
// public  record GetWeightHistoryQuery(long UserId) : IRequest<RequestResult<IReadOnlyCollection<WeightHistoryDto>>>;
// public  record GetAchievementsQuery(long UserId) : IRequest<RequestResult<IReadOnlyCollection<AchievementDto>>>;
// public  record GetUserStatisticsQuery(long UserId) : IRequest<RequestResult<UserStatisticsDto>>;

// public  class GetProgressQueryHandler : BaseHandler<GetProgressQuery, RequestResult<ProgressSummaryDto>>
// {
//     private readonly IMapper _mapper;
//     public GetProgressQueryHandler(BaseParameters baseParameters, IMapper mapper) : base(baseParameters) => _mapper = mapper;

//     public override async Task<RequestResult<ProgressSummaryDto>> Handle(GetProgressQuery request, CancellationToken cancellationToken)
//     {
//         var endDate = request.EndDate?.ToUniversalTime() ?? DateTime.UtcNow;
//         var startDate = request.StartDate?.ToUniversalTime() ?? GetStartDate(request.Period, endDate);
//         var workouts = await _context.WorkoutLogs
//             .Where(log => log.UserId == request.UserId && log.CompletedAt >= startDate && log.CompletedAt <= endDate)
//             .ToListAsync(cancellationToken);
//         var statistics = await _context.UserStatisticss.FindAsync([request.UserId], cancellationToken);
//         var streak = await _context.Streaks.SingleOrDefaultAsync(item => item.UserId == request.UserId, cancellationToken);

//         return RequestResult<ProgressSummaryDto>.Success(new ProgressSummaryDto
//         {
//             UserId = request.UserId,
//             CompletedWorkouts = workouts.Count,
//             CaloriesBurned = workouts.Sum(log => log.CaloriesBurned),
//             CurrentWeight = statistics?.CurrentWeight,
//             Streak = streak is null ? null : _mapper.Map<StreakDto>(streak)
//         });
//     }

//     private  DateTime GetStartDate(string? period, DateTime endDate) => period?.ToLowerInvariant() switch
//     {
//         "week" => endDate.AddDays(-7),
//         "month" => endDate.AddMonths(-1),
//         "year" => endDate.AddYears(-1),
//         _ => DateTime.MinValue
//     };
// }

// public  class GetWeightHistoryQueryHandler : BaseHandler<GetWeightHistoryQuery, RequestResult<IReadOnlyCollection<WeightHistoryDto>>>
// {
//     private readonly IMapper _mapper;
//     public GetWeightHistoryQueryHandler(BaseParameters baseParameters, IMapper mapper) : base(baseParameters) => _mapper = mapper;
//     public override async Task<RequestResult<IReadOnlyCollection<WeightHistoryDto>>> Handle(GetWeightHistoryQuery request, CancellationToken cancellationToken)
//     {
//         var items = await _context.WeightHistory.Where(item => item.UserId == request.UserId)
//             .OrderByDescending(item => item.Date).ToListAsync(cancellationToken);
//         return RequestResult<IReadOnlyCollection<WeightHistoryDto>>.Success(_mapper.Map<List<WeightHistoryDto>>(items));
//     }
// }

// public  class GetAchievementsQueryHandler : BaseHandler<GetAchievementsQuery, RequestResult<IReadOnlyCollection<AchievementDto>>>
// {
//     public GetAchievementsQueryHandler(BaseParameters baseParameters) : base(baseParameters) { }
//     public override async Task<RequestResult<IReadOnlyCollection<AchievementDto>>> Handle(GetAchievementsQuery request, CancellationToken cancellationToken)
//     {
//         var items = await _context.UserAchievements.Where(item => item.UserId == request.UserId)
//             .Include(item => item.Achievement).OrderByDescending(item => item.EarnedAt)
//             .Select(item => new AchievementDto { Id = item.AchievementId, Name = item.Achievement.Name, Description = item.Achievement.Description, IconUrl = item.Achievement.IconUrl, EarnedAt = item.EarnedAt })
//             .ToListAsync(cancellationToken);
//         return RequestResult<IReadOnlyCollection<AchievementDto>>.Success(items);
//     }
// }

// public  class GetUserStatisticsQueryHandler : BaseHandler<GetUserStatisticsQuery, RequestResult<UserStatisticsDto>>
// {
//     private readonly IMapper _mapper;
//     public GetUserStatisticsQueryHandler(BaseParameters baseParameters, IMapper mapper) : base(baseParameters) => _mapper = mapper;
//     public override async Task<RequestResult<UserStatisticsDto>> Handle(GetUserStatisticsQuery request, CancellationToken cancellationToken)
//     {
//         var statistics = await _context.UserStatisticss.FindAsync([request.UserId], cancellationToken);
//         return statistics is null
//             ? RequestResult<UserStatisticsDto>.Failure(ErrorCode.BadRequest, "Statistics were not found.")
//             : RequestResult<UserStatisticsDto>.Success(_mapper.Map<UserStatisticsDto>(statistics));
//     }
// }
