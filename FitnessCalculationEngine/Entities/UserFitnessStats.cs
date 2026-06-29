using FitnessCalculationEngine.Common.Enums;

namespace FitnessCalculationEngine.Entities
{
    public class UserFitnessStats : BaseInformation
    {
        public long UserId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public long GenderId { get; set; }
        public Lookup Gender { get; set; }
        public long GoalId { get; set; }
        public Lookup Goal { get; set; }
        public long ActivityLevelId { get; set; }
        public Lookup ActivityLevel { get; set; }

    }
}
