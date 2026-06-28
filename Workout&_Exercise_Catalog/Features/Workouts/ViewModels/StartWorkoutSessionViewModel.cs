namespace Workout_Exercise_Catalog.Features.Workouts.ViewModels
{
    public record StartWorkoutSessionViewModel(
        long Id,
        IReadOnlyCollection<WorkoutExerciseViewModel> Exercises);
}
