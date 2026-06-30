using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Entities;
using FitnessCalculationEngine.Features.UserAssignedPlanFeature.Queries.GetAssignedPlan;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Features.UserAssignedPlanFeature.Queries.GetAssignedPlanQueryHandler
{
    public class GetAssignedPlanQueryHandler : BaseHandler<GetAssignedPlanQuery, RequestResult<UserAssignedPlan>>
    {

        public GetAssignedPlanQueryHandler(BaseParameters parameters) : base(parameters)
        {
            
        }
        public override async Task<RequestResult<UserAssignedPlan>> Handle(GetAssignedPlanQuery request, CancellationToken cancellationToken)
        {
            var assignedPlan = await _context.UserAssignedPlans
                .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.IsActive, cancellationToken);

            return RequestResult<UserAssignedPlan>.Success(assignedPlan);
        }
    }
}
