using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.UserFitnessStatsFeature.command;
using FitnessCalculationEngine.Features.UserFitnessStatsFeature.ViewModels;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCalculationEngine.Features.UserFitnessStatsFeature.EndPoint
{
    [Route("api/v1/fitness/weight-goal-activity/[controller]")]
    [ApiController]
    [Authorize]
    public class UserFitnessStatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserFitnessStatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> SubmitUserFitnessStats([FromBody] SubmitUserFitnessStatsViewModel submitUserFitnessStatsViewModel)
        {
            var command = submitUserFitnessStatsViewModel.Adapt<SubmitUserFitnessStatsCommand>();
            
            var result = await _mediator.Send(command);

            return EndpointResponse<bool>.Success(result);
        }
    }
}
