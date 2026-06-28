using Workout_Exercise_Catalog.Entities;

namespace Workout_Exercise_Catalog.Entities;

public class Workout : BaseEntity
{
    //public int Id { get; set; }

    public int WorkoutPlanId { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; } 

    public string Difficulty { get; set; } = null!;

    public int DurationInMinutes { get; set; }

    public int CaloriesBurn { get; set; }

    public int OrderIndex { get; set; }

    public string ImageUrl { get; set; } = null!;

    public bool IsPremium { get; set; }

    public WorkoutPlan WorkoutPlan { get; set; } = null!;
    //public string Category { get; set; } = null!;
    public Category Category { get; set; } = null!;


    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = null;

    public ICollection<WorkoutSession> WorkoutSessions { get; set; } = null;
}
