using FitnessCalculationEngine.Common.Enums;

namespace FitnessCalculationEngine.Features.RecalculateMetricsFeature.ViewModels
{
    public class CalculateMetricsResponseViewModel
    {
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public double CalorieTarget { get; set; }
        public LookupEnum Status { get; set; }
    }
}
