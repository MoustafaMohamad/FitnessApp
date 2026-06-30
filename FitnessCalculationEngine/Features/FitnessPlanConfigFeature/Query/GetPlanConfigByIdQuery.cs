using MediatR;

namespace FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query
{
    public record GetPlanConfigByIdQuery(long Id) : IRequest<PlanConfigDto>;
}
