using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.ResultPattern;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query
{
    public class GetMatchingPlanConfigQueryHandler : BaseHandler<GetMatchingPlanConfigQuery, RequestResult<PlanConfigDto>>
    {
        public GetMatchingPlanConfigQueryHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<PlanConfigDto>> Handle(GetMatchingPlanConfigQuery request, CancellationToken cancellationToken)
        {
            var config = await _context.FitnessPlanConfigs
                .Where(x => x.Goal.ToLower() == request.Goal.ToLower() && x.Status.ToLower() == request.Status.ToLower())
                .Select(x => new PlanConfigDto
                {
                    Id = x.Id,
                    Goal = x.Goal,
                    Status = x.Status,
                    CalorieMin = x.CalorieMin,
                    CalorieMax = x.CalorieMax,
                    ExternalPlanId = x.ExternalPlanId,
                    PlanName = x.PlanName,
                    WorkoutsPerWeek = x.WorkoutsPerWeek
                })
                .FirstOrDefaultAsync(cancellationToken);

            return RequestResult<PlanConfigDto>.Success(config);
        }
    }
}
