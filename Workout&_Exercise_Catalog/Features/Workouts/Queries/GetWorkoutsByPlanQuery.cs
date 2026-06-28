using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.Workouts.Dtos;

namespace Workout_Exercise_Catalog.Features.Workouts.Queries
{
    public record GetWorkoutsByPlanQuery(int PlanId) : IRequest<RequestResult<IReadOnlyCollection<WorkoutListItemDto>>>;

    public class GetWorkoutsByPlanQueryHandler : BaseRequestHandler<GetWorkoutsByPlanQuery, RequestResult<IReadOnlyCollection<WorkoutListItemDto>>>
    {

        public GetWorkoutsByPlanQueryHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<IReadOnlyCollection<WorkoutListItemDto>>> Handle(GetWorkoutsByPlanQuery request, CancellationToken cancellationToken)
        {
            var planExists = await _context.WorkoutPlans.AnyAsync(x => x.Id == request.PlanId, cancellationToken);
            if (!planExists)
            {
                return RequestResult<IReadOnlyCollection<WorkoutListItemDto>>.Failure(ErrorCode.RES_PLAN_NOT_FOUND);
            }

            var workouts = await _context.Workouts
                .AsNoTracking()
                .Where(x => x.WorkoutPlanId == request.PlanId)
                .OrderBy(x => x.OrderIndex)
                .Map<WorkoutListItemDto>()
                .ToListAsync(cancellationToken);

            return RequestResult<IReadOnlyCollection<WorkoutListItemDto>>.Success(workouts);
        }
    }
}
