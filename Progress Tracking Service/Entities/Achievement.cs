namespace Progress_Tracking_Service.Entities;

public class Achievement : BaseInformation
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IconUrl { get; set; } = string.Empty;

    public ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
