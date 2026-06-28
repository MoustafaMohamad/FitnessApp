namespace Workout_Exercise_Catalog.Features.Exercises.Dtos
{
    public record ExerciseDetailDto(
        long Id,
        string Name,
        string TargetMuscles,
        string Equipment,
        string Description,
        string VideoUrl);
}
