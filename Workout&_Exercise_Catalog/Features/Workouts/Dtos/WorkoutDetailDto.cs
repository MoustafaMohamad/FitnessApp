namespace Workout_Exercise_Catalog.Features.Workouts.Dtos
{
    public record WorkoutDetailDto(
        long Id,
        int WorkoutPlanId,
        string PlanName,
        string Name,
        string Category,
        string Difficulty,
        int DurationInMinutes,
        int CaloriesBurn,
        int OrderIndex,
        string ImageUrl,
        bool IsPremium,
        IReadOnlyCollection<WorkoutExerciseDto> Exercises);
}
