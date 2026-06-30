using FitnessCalculationEngine.Common.Enums;

namespace FitnessCalculationEngine.Entities
{
    public class Lookup
    {
        public LookupEnum Id { get; set; }
        public string Name { get; set; }
        public LookupCategoryEnum CategoryId { get; set; }
        public double Value { get; set; }
    }
}
