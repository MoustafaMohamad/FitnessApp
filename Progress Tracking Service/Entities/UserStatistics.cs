namespace Progress_Tracking_Service.Entities;

public class UserStatistics : BaseInformation
{
    public int TotalWorkouts { get; set; }
    public int TotalCaloriesBurned { get; set; }
    public double CurrentWeight { get; set; }
    public double StartWeight { get; set; }
    public double TotalWeightLost { get; set; }
}
