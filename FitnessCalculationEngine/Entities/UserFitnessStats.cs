namespace FitnessCalculationEngine.Entities
{
    public class UserFitnessStats : BaseInformation
    {
        public long UserId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public Common.Enums.Gender Gender { get; set; }
        public Common.Enums.Goal Goal { get; set; }
        public Common.Enums.ActivityLevel ActivityLevel { get; set; }

    }
}
