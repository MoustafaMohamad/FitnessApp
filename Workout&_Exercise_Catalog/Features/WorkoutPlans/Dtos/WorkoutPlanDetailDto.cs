namespace Workout_Exercise_Catalog.Features.WorkoutPlans.Dtos
{
    public record WorkoutPlanDetailDto(
        long Id,
        string ExternalPlanId,
        string Name,
        string Goal,
        string Status,
        string Difficulty,
        string Description);
}
