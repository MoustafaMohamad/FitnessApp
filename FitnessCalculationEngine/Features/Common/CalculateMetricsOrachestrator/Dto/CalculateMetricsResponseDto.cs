using FitnessCalculationEngine.Common.Enums;

namespace FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Dto
{
    public class CalculateMetricsResponseDto
    {
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public double CalorieTarget { get; set; }
        public LookupEnum Status { get; set; }
    }
}
