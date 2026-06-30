using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Entities;
using MediatR;

namespace FitnessCalculationEngine.Features.UserAssignedPlanFeature.Queries.GetAssignedPlan
{
    public record GetAssignedPlanQuery(long UserId) : IRequest<RequestResult<UserAssignedPlan>>;
    
}
