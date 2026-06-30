using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query
{
    public class GetPlanConfigByIdQueryHandler : BaseHandler<GetPlanConfigByIdQuery, PlanConfigDto>
    {
        public GetPlanConfigByIdQueryHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<PlanConfigDto> Handle(GetPlanConfigByIdQuery request, CancellationToken cancellationToken)
        {
            var config = await _context.FitnessPlanConfigs
                .Where(x => x.Id == request.Id)
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

            if (config == null)
            {
                throw new BusinessException(ErrorCode.BadRequest, "RES_PLAN_NOT_FOUND");
            }

            return config;
        }
    }
}
