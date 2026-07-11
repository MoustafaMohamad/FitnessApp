using Microsoft.EntityFrameworkCore;

namespace Progress_Tracking_Service.Entities;

[Index(nameof(UserId))]
public class BodyMeasurement : BaseInformation
{
    public long UserId { get; set; }
    public double? Neck { get; set; }
    public double? Chest { get; set; }
    public double? Biceps { get; set; }
    public double? Waist { get; set; }
    public double? Hips { get; set; }
    public double? Thighs { get; set; }
    public DateTime RecordedAt { get; set; }
}
