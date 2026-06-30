namespace FitnessCalculationEngine.Entities
{
    public class FitnessPlanConfig : BaseInformation
    {
        public string Goal { get; set; }

        public string Status { get; set; }

        public double CalorieMin { get; set; }

        public double CalorieMax { get; set; }

        public string ExternalPlanId { get; set; }

        public string PlanName { get; set; }

        public int WorkoutsPerWeek { get; set; }
    }
}
