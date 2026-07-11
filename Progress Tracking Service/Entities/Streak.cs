namespace Progress_Tracking_Service.Entities;

public class Streak : BaseInformation
{
    public long UserId { get; set; }
    public int CurrentStreak { get; set; }
    public int LongestStreak { get; set; }
    public DateTime? LastWorkoutDate { get; set; }
}
