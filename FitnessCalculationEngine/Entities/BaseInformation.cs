namespace FitnessCalculationEngine.Entities
{
    public class BaseInformation
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long CreatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedById { get; set; }
        public bool IsActive { get; set; }

    }
}
