namespace Workout_Exercise_Catalog.Features.Exercises.ViewModels
{
    public record ExerciseDetailViewModel(
        long Id,
        string Name,
        string TargetMuscles,
        string Equipment,
        string Description,
        string VideoUrl);
}
