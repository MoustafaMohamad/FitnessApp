namespace Workout_Exercise_Catalog.Features.WorkoutPlans.ViewModels
{
    public record WorkoutPlanListItemViewModel(
        long Id,
        string ExternalPlanId,
        string Name,
        string Goal,
        string Status,
        string Difficulty);
}
