using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.Common.BaseHandler;
using ProgressTrackingService.Common.ResultPattern;
using ProgressTrackingService.Features.Progress.Dtos;

namespace ProgressTrackingService.Features.Progress.Queries;

public record GetAchievementsQuery(long UserId) : IRequest<RequestResult<IReadOnlyCollection<AchievementDto>>>;

public class GetAchievementsQueryHandler : BaseHandler<GetAchievementsQuery, RequestResult<IReadOnlyCollection<AchievementDto>>>
{
    public GetAchievementsQueryHandler(BaseParameters baseParameters) : base(baseParameters) { }

    public override async Task<RequestResult<IReadOnlyCollection<AchievementDto>>> Handle(GetAchievementsQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.UserAchievements.Where(item => item.UserId == request.UserId)
            .Include(item => item.Achievement)
            .OrderByDescending(item => item.EarnedAt)
            .Select(item => new AchievementDto
            {
                Id = item.AchievementId,
                Name = item.Achievement.Name,
                Description = item.Achievement.Description,
                IconUrl = item.Achievement.IconUrl,
                EarnedAt = item.EarnedAt
            })
            .ToListAsync(cancellationToken);

        return RequestResult<IReadOnlyCollection<AchievementDto>>.Success(items);
    }
}
