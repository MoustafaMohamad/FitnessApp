using FitnessCalculationEngine.Common.ResultPattern;
using MediatR;

namespace FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query
{
    public record GetMatchingPlanConfigQuery(string Goal, string Status) : IRequest<RequestResult<PlanConfigDto>>;
}
