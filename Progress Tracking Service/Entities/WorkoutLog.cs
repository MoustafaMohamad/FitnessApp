using Microsoft.EntityFrameworkCore;

namespace Progress_Tracking_Service.Entities;

[Index(nameof(UserId))]
[Index(nameof(SessionId), IsUnique = true)]
public class WorkoutLog : BaseInformation
{
    public long UserId { get; set; }
    public long WorkoutId { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
    public int CaloriesBurned { get; set; }
    public int Rating { get; set; }
    public string? Notes { get; set; }
    public DateTime CompletedAt { get; set; }

    public ICollection<WorkoutLogExercise> Exercises { get; set; } = new List<WorkoutLogExercise>();
}
