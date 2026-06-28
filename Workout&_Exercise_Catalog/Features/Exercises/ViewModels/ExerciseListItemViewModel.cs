namespace Workout_Exercise_Catalog.Features.Exercises.ViewModels
{
    public record ExerciseListItemViewModel(
        long Id,
        string Name,
        string TargetMuscles,
        string Equipment,
        string Difficulty);
}
