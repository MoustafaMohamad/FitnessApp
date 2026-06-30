using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.CalculatedMetricsFeature.Command;
using FitnessCalculationEngine.Features.CalculatedMetricsFeature.ViewModels;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Dto;
using MediatR;
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
        public async Task<EndpointResponse<CalculateMetricsResponseDto>> Calculate([FromBody] CalculateMetricsRequestViewModel request, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CalculateMetricsOrachestrator(request.UserId), cancellationToken);
            if (result.IsSuccess)
                return EndpointResponse<CalculateMetricsResponseDto>.Success(result.Data, result.Message);
            else
                return EndpointResponse<CalculateMetricsResponseDto>.Failure(result.ErrorCode,result.Message);
        }


    }
}
