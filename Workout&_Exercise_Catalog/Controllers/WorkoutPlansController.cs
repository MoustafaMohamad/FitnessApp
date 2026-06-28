using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workout_Exercise_Catalog.Features.Common.ViewModels;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.WorkoutPlans.Queries;
using Workout_Exercise_Catalog.Features.WorkoutPlans.ViewModels;

namespace Workout_Exercise_Catalog.Controllers
{
    [ApiController]
    [Route("api/v1/workout-plans")]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WorkoutPlansController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Browse(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetWorkoutPlansQuery(page, pageSize), cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(EndpointResponse<PagedResultViewModel<WorkoutPlanListItemViewModel>>.Failure(result.ErrorCode, result.Message));
            }

            var viewModel = new PagedResultViewModel<WorkoutPlanListItemViewModel>(
                _mapper.Map<IReadOnlyCollection<WorkoutPlanListItemViewModel>>(result.Data.Items),
                result.Data.Page,
                result.Data.PageSize,
                result.Data.TotalCount,
                result.Data.TotalPages);

            return Ok(EndpointResponse<PagedResultViewModel<WorkoutPlanListItemViewModel>>.Success(viewModel, result.Message));
        }

        [HttpGet("{planId:int}")]
        public async Task<IActionResult> Details(int planId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetWorkoutPlanDetailQuery(planId), cancellationToken);
            if (!result.IsSuccess)
            {
                return NotFound(EndpointResponse<WorkoutPlanDetailViewModel>.Failure(result.ErrorCode, result.Message));
            }

            return Ok(EndpointResponse<WorkoutPlanDetailViewModel>.Success(_mapper.Map<WorkoutPlanDetailViewModel>(result.Data), result.Message));
        }
    }
}
