using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.Common.ViewModel;
using FitnessCalculationEngine.Features.RecalculateMetricsFeature.Orachestrator;
using FitnessCalculationEngine.Features.RecalculateMetricsFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCalculationEngine.Features.RecalculateMetricsFeature.EndPoint
{
    [Route("api/v1/fitness/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReCalculatedMetricsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReCalculatedMetricsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPut("recalculate/{userId}")]
        public async Task<EndpointResponse<CalculateMetricsResponseViewModel>> Recalculate(
            [FromRoute] long userId,
            [FromBody] RecalculateMetricsRequestViewModel request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new RecalculateMetricsOrachestrator(userId, request.NewWeight, request.Reason), cancellationToken);
                                              

            var response = new CalculateMetricsResponseViewModel
            {

                BMR = result.Data.BMR,
                TDEE = result.Data.TDEE,
                CalorieTarget = result.Data.CalorieTarget,
                Status = result.Data.Status
            };
            return EndpointResponse<CalculateMetricsResponseViewModel>.Success(response);
        }
    }
}
