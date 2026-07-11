namespace Progress_Tracking_Service.Entities;

public class WorkoutLogExercise : BaseInformation
{
    public long WorkoutLogId { get; set; }
    public long ExerciseId { get; set; }
    public int SetsCompleted { get; set; }
    public int RepsCompleted { get; set; }
    public double WeightUsed { get; set; }
    public bool Completed { get; set; }

    public WorkoutLog WorkoutLog { get; set; } = null!;
}
