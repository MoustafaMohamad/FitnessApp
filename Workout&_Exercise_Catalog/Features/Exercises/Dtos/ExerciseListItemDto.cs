namespace Workout_Exercise_Catalog.Features.Exercises.Dtos
{
    public record ExerciseListItemDto(
        long Id,
        string Name,
        string TargetMuscles,
        string Equipment,
        string Difficulty);
}
