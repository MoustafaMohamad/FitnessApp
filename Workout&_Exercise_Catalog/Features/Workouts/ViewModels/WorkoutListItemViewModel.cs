namespace Workout_Exercise_Catalog.Features.Workouts.ViewModels
{
    public record WorkoutListItemViewModel(
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
