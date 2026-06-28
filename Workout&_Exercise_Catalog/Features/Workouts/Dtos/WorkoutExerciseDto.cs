namespace Workout_Exercise_Catalog.Features.Workouts.Dtos
{
    public record WorkoutExerciseDto(
        long Id,
        int ExerciseId,
        string Name,
        string TargetMuscles,
        string Equipment,
        string Description,
        string VideoUrl,
        int OrderIndex,
        int SetsDefault,
        string RepsDefault,
        int RestTimeInSeconds);
}
