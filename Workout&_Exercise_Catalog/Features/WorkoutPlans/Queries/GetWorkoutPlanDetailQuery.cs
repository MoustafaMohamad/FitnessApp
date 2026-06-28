using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.WorkoutPlans.Dtos;

namespace Workout_Exercise_Catalog.Features.WorkoutPlans.Queries
{
    public record GetWorkoutPlanDetailQuery(int PlanId) : IRequest<RequestResult<WorkoutPlanDetailDto>>;

    public class GetWorkoutPlanDetailQueryHandler : BaseRequestHandler<GetWorkoutPlanDetailQuery, RequestResult<WorkoutPlanDetailDto>>
    {

        public GetWorkoutPlanDetailQueryHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<WorkoutPlanDetailDto>> Handle(GetWorkoutPlanDetailQuery request, CancellationToken cancellationToken)
        {
            var plan = await _context.WorkoutPlans
                .AsNoTracking()
                .Where(x => x.Id == request.PlanId)
                .Map< WorkoutPlanDetailDto>()
                .FirstOrDefaultAsync(cancellationToken);

            return plan is null
                ? RequestResult<WorkoutPlanDetailDto>.Failure(ErrorCode.RES_PLAN_NOT_FOUND)
                : RequestResult<WorkoutPlanDetailDto>.Success(plan);
        }
    }
}
