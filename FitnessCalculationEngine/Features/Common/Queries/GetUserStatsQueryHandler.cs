
using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.ResultPattern;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Features.Common.Queries
{
    public class GetUserStatsQueryHandler : BaseHandler<GetUserStatsQuery, RequestResult<UserStatsDto>>
    {
        public GetUserStatsQueryHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<UserStatsDto>> Handle(GetUserStatsQuery request, CancellationToken cancellationToken)
        {
            var userStats = await _context.UserFitnessStats
                .Where(u => u.UserId == request.UserId)
                .Select(u => new UserStatsDto
                {
                    UserId = u.UserId,
                    Weight = u.Weight,
                    Height = u.Height,
                    Age = u.Age,
                    GenderEnumId = u.GenderId,
                    ActivityFactor = u.ActivityLevel.Value,
                    CalorieOffset = u.Goal.Value,
                    GoalName = u.Goal.Name
                })
                .FirstOrDefaultAsync(cancellationToken);

            return  RequestResult<UserStatsDto>.Success(userStats);
        }
    }
}
