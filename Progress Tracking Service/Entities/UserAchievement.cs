using Microsoft.EntityFrameworkCore;

namespace Progress_Tracking_Service.Entities;

[Index(nameof(UserId))]
[Index(nameof(UserId), nameof(AchievementId), IsUnique = true)]
public class UserAchievement : BaseInformation
{
    public long UserId { get; set; }
    public long AchievementId { get; set; }
    public DateTime EarnedAt { get; set; }

    public Achievement Achievement { get; set; } = null!;
}
