using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.Workouts.Dtos;

namespace Workout_Exercise_Catalog.Features.Workouts.Queries
{
    public record GetWorkoutDetailsQuery(int Id) : IRequest<RequestResult<WorkoutDetailDto>>;

    public class GetWorkoutDetailsQueryHandler : BaseRequestHandler<GetWorkoutDetailsQuery, RequestResult<WorkoutDetailDto>>
    {

        public GetWorkoutDetailsQueryHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<WorkoutDetailDto>> Handle(GetWorkoutDetailsQuery request, CancellationToken cancellationToken)
        {
            var workout = await _context.Workouts
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new WorkoutDetailDto(
                    x.Id,
                    x.WorkoutPlanId,
                    x.WorkoutPlan.Name,
                    x.Name,
                    x.Category.Name,
                    x.Difficulty,
                    x.DurationInMinutes,
                    x.CaloriesBurn,
                    x.OrderIndex,
                    x.ImageUrl,
                    x.IsPremium,
                    x.WorkoutExercises
                        .OrderBy(we => we.OrderIndex)
                        .Select(we => new WorkoutExerciseDto(
                            we.Id,
                            we.ExerciseId,
                            we.Exercise.Name,
                            we.Exercise.TargetMuscles,
                            we.Exercise.EquipmentNeeded,
                            we.Exercise.Description,
                            we.Exercise.VideoUrl,
                            we.OrderIndex,
                            we.SetsDefault,
                            we.RepsDefault,
                            we.RestTimeInSeconds))
                        .ToList()))
                .FirstOrDefaultAsync(cancellationToken);

            return workout is null
                ? RequestResult<WorkoutDetailDto>.Failure(ErrorCode.RES_WORKOUT_NOT_FOUND)
                : RequestResult<WorkoutDetailDto>.Success(workout);
        }
    }
}
