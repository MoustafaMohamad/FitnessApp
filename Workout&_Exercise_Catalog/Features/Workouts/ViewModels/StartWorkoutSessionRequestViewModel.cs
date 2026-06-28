namespace Workout_Exercise_Catalog.Features.Workouts.ViewModels
{
    public record StartWorkoutSessionRequestViewModel(
        string? Difficulty,
        int? PlannedDuration);
}
