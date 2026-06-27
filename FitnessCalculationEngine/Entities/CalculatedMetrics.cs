namespace FitnessCalculationEngine.Entities
{
    public class CalculatedMetrics : BaseInformation
    {
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public double CalorieTarget { get; set; }
        public string Status { get; set; }
    }
}
