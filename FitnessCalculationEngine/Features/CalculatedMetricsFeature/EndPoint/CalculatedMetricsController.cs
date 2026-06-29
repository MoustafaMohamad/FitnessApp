using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.CalculatedMetricsFeature.Command;
using FitnessCalculationEngine.Features.CalculatedMetricsFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCalculationEngine.Features.CalculatedMetricsFeature.EndPoint
{
    [Route("api/v1/fitness/[controller]")]
    [ApiController]
    //[Authorize]
    public class CalculateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<EndpointResponse<CalculateMetricsResponseViewModel>> Calculate([FromBody] CalculateMetricsRequestViewModel request,CancellationToken cancellationToken)
        {
   
            var result = await _mediator.Send( new CalculateMetricsCommand(request.UserId), cancellationToken);
            return EndpointResponse<CalculateMetricsResponseViewModel>.Success(result);
        }
    }
}
