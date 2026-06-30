using FitnessCalculationEngine.Common.Enums;

namespace FitnessCalculationEngine.Entities
{
    public class UserFitnessStats : BaseInformation
    {
        public long UserId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public LookupEnum GenderId { get; set; }
        public Lookup Gender { get; set; }
        public LookupEnum GoalId { get; set; }
        public Lookup Goal { get; set; }
        public LookupEnum ActivityLevelId { get; set; }
        public Lookup ActivityLevel { get; set; }

    }
}
