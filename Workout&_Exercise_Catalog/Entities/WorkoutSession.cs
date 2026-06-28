namespace Workout_Exercise_Catalog.Entities;

public class WorkoutSession:BaseEntity
{
   // public string SessionId { get; set; } = Guid.NewGuid().ToString();

    public int UserId { get; set; }

    public int WorkoutId { get; set; }

    public DateTime StartedAt { get; set; }

    public string Status { get; set; } = null!;

    public Workout Workout { get; set; } = null!;
}