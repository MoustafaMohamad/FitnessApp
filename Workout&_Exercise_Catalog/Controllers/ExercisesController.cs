using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workout_Exercise_Catalog.Features.Common.ViewModels;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.Exercises.Queries;
using Workout_Exercise_Catalog.Features.Exercises.ViewModels;

namespace Workout_Exercise_Catalog.Controllers
{
    [ApiController]
    [Route("api/v1/exercises")]
    public class ExercisesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;




        public ExercisesController(IMediator mediator, IMapper mapper)
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
            var result = await _mediator.Send(new GetExercisesQuery(page, pageSize), cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(EndpointResponse<PagedResultViewModel<ExerciseListItemViewModel>>.Failure(result.ErrorCode, result.Message));
            }

            var viewModel = new PagedResultViewModel<ExerciseListItemViewModel>(
                _mapper.Map<IReadOnlyCollection<ExerciseListItemViewModel>>(result.Data.Items),
                result.Data.Page,
                result.Data.PageSize,
                result.Data.TotalCount,
                result.Data.TotalPages);

            return Ok(EndpointResponse<PagedResultViewModel<ExerciseListItemViewModel>>.Success(viewModel, result.Message));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetExerciseDetailQuery(id), cancellationToken);
            if (!result.IsSuccess)
            {
                return NotFound(EndpointResponse<ExerciseDetailViewModel>.Failure(result.ErrorCode, result.Message));
            }

            return Ok(EndpointResponse<ExerciseDetailViewModel>.Success(_mapper.Map<ExerciseDetailViewModel>(result.Data), result.Message));
        }
    }
}
