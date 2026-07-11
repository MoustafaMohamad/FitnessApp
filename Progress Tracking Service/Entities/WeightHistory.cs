using Microsoft.EntityFrameworkCore;

namespace Progress_Tracking_Service.Entities;

[Index(nameof(UserId))]
public class WeightHistory : BaseInformation
{
    public long UserId { get; set; }
    public double Weight { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
}
