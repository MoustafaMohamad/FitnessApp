using FitnessCalculationEngine.Common.Enums;

namespace FitnessCalculationEngine.Entities
{
    public class CalculatedMetrics : BaseInformation
    {
        public long UserId { get; set; }
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public double CalorieTarget { get; set; }
        public LookupEnum StatusId { get; set; }
        public Lookup Status { get; set; }
    }
}
