namespace Workout_Exercise_Catalog.Features.Workouts.Dtos
{
    public record StartWorkoutSessionDto(
        long Id,
        IReadOnlyCollection<WorkoutExerciseDto> Exercises);
}
