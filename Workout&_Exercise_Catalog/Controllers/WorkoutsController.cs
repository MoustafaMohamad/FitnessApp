using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.ViewModels;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.Workouts.Commands;
using Workout_Exercise_Catalog.Features.Workouts.Queries;
using Workout_Exercise_Catalog.Features.Workouts.ViewModels;

namespace Workout_Exercise_Catalog.Controllers
{
    [ApiController]
    [Route("api/v1/workouts")]
    public class WorkoutsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WorkoutsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Browse(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? category = null,
            [FromQuery] string? difficulty = null,
            [FromQuery] int? duration = null,
            [FromQuery] string? search = null,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetWorkoutsQuery(page, pageSize, category, difficulty, duration, search), cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(EndpointResponse<PagedResultViewModel<WorkoutListItemViewModel>>.Failure(result.ErrorCode, result.Message));
            }

            var viewModel = new PagedResultViewModel<WorkoutListItemViewModel>(
                _mapper.Map<IReadOnlyCollection<WorkoutListItemViewModel>>(result.Data.Items),
                result.Data.Page,
                result.Data.PageSize,
                result.Data.TotalCount,
                result.Data.TotalPages);

            return Ok(EndpointResponse<PagedResultViewModel<WorkoutListItemViewModel>>.Success(viewModel, result.Message));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetWorkoutDetailsQuery(id), cancellationToken);
            if (!result.IsSuccess)
            {
                return NotFound(EndpointResponse<WorkoutDetailViewModel>.Failure(result.ErrorCode, result.Message));
            }

            return Ok(EndpointResponse<WorkoutDetailViewModel>.Success(_mapper.Map<WorkoutDetailViewModel>(result.Data), result.Message));
        }

        [HttpGet("by-plan/{planId:int}")]
        public async Task<IActionResult> ByPlan(int planId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetWorkoutsByPlanQuery(planId), cancellationToken);
            if (!result.IsSuccess)
            {
                return NotFound(EndpointResponse<IReadOnlyCollection<WorkoutListItemViewModel>>.Failure(result.ErrorCode, result.Message));
            }

            return Ok(EndpointResponse<IReadOnlyCollection<WorkoutListItemViewModel>>.Success(
                _mapper.Map<IReadOnlyCollection<WorkoutListItemViewModel>>(result.Data),
                result.Message));
        }

        [HttpGet("category/{categoryName}")]
        public async Task<IActionResult> ByCategory(string categoryName, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetWorkoutsByCategoryQuery(categoryName), cancellationToken);
            if (!result.IsSuccess)
            {
                return NotFound(EndpointResponse<IReadOnlyCollection<WorkoutListItemViewModel>>.Failure(result.ErrorCode, result.Message));
            }

            return Ok(EndpointResponse<IReadOnlyCollection<WorkoutListItemViewModel>>.Success(
                _mapper.Map<IReadOnlyCollection<WorkoutListItemViewModel>>(result.Data),
                result.Message));
        }

        [HttpPost("{id:int}/start")]
        public async Task<IActionResult> Start(
            int id,
            [FromBody] StartWorkoutSessionRequestViewModel request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new StartWorkoutSessionCommand(id, request.Difficulty, request.PlannedDuration), cancellationToken);
            if (!result.IsSuccess)
            {
                return NotFound(EndpointResponse<StartWorkoutSessionViewModel>.Failure(result.ErrorCode, result.Message));
            }

            return StatusCode(
                StatusCodes.Status201Created,
                EndpointResponse<StartWorkoutSessionViewModel>.Success(
                    _mapper.Map<StartWorkoutSessionViewModel>(result.Data),
                    result.Message));
        }
    }
}
