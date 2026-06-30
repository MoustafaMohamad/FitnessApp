using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCalculationEngine.Features.FitnessPlanConfigFeature.EndPoint
{
    [Route("api/v1/fitness/plan-configs")]
    [ApiController]
    //[Authorize]
    public class PlanConfigsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanConfigsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<EndpointResponse<PagedResult<PlanConfigDto>>> GetPlanConfigs(
            [FromQuery] string? goal,
            [FromQuery] string? status,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20,
            CancellationToken cancellationToken = default)
        {
            var query = new GetPlanConfigsQuery(goal, status, page, pageSize);
            var result = await _mediator.Send(query, cancellationToken);
            return EndpointResponse<PagedResult<PlanConfigDto>>.Success(result);
        }

        [HttpGet("~/api/v1/fitness/plans/{planId}")]
        public async Task<EndpointResponse<PlanConfigDto>> GetPlanConfigById([FromRoute] long planId, CancellationToken cancellationToken = default)
        {
            var query = new GetPlanConfigByIdQuery(planId);
            var result = await _mediator.Send(query, cancellationToken);
            return EndpointResponse<PlanConfigDto>.Success(result);
        }
    }
}
