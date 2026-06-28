namespace Workout_Exercise_Catalog.Features.Workouts.Dtos
{
    public record WorkoutListItemDto(
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
        bool IsPremium);
}
