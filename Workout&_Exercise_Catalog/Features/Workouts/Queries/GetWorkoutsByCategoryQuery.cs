using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Queries.Categories;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.Workouts.Dtos;

namespace Workout_Exercise_Catalog.Features.Workouts.Queries
{
    public record GetWorkoutsByCategoryQuery(string CategoryName) : IRequest<RequestResult<IReadOnlyCollection<WorkoutListItemDto>>>;

    public class GetWorkoutsByCategoryQueryHandler : BaseRequestHandler<GetWorkoutsByCategoryQuery, RequestResult<IReadOnlyCollection<WorkoutListItemDto>>>
    {

        public GetWorkoutsByCategoryQueryHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<IReadOnlyCollection<WorkoutListItemDto>>> Handle(GetWorkoutsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryExists = await _mediator.Send(new IsCategoryExistQuery(request.CategoryName), cancellationToken);
            if (!categoryExists.Data)
            {
                return RequestResult<IReadOnlyCollection<WorkoutListItemDto>>.Failure(ErrorCode.RES_NOT_FOUND);
            }

            var category = request.CategoryName.Trim().ToLower();

            var workouts = await _context.Workouts
                .AsNoTracking()
                .Where(x => x.Category.Name.ToLower() == category)
                .OrderBy(x => x.OrderIndex)
                .Map<WorkoutListItemDto>()
                .ToListAsync(cancellationToken);

            return RequestResult<IReadOnlyCollection<WorkoutListItemDto>>.Success(workouts);
        }
    }
}
