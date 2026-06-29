namespace FitnessCalculationEngine.Features.CalculatedMetricsFeature.ViewModels
{
    public class CalculateMetricsResponseViewModel
    {
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public double CalorieTarget { get; set; }
        public long StatusId { get; set; }
    }
}
