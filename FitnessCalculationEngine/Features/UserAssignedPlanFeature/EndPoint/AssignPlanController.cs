using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query;
using FitnessCalculationEngine.Features.UserAssignedPlanFeature.Command;
using FitnessCalculationEngine.Features.UserAssignedPlanFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCalculationEngine.Features.UserAssignedPlanFeature.EndPoint
{
    [Route("api/v1/fitness/[controller]")]
    [ApiController]
    //[Authorize]
    public class AssignPlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssignPlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("~/api/v1/fitness/assign-plan")]
        public async Task<EndpointResponse<PlanConfigDto>> AssignPlan([FromBody] AssignFitnessPlanRequestViewModel request, CancellationToken cancellationToken)
        {
            var command = new AssignFitnessPlanOrachestrator(request.UserId);
            var result = await _mediator.Send(command, cancellationToken);
            return EndpointResponse<PlanConfigDto>.Success(result);
        }
    }
}
