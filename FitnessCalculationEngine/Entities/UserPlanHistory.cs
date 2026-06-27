using System;

namespace FitnessCalculationEngine.Entities
{
    public class UserPlanHistory : BaseInformation
    {
        public int UserId { get; set; }
        public string ExternalPlanId { get; set; }
        public DateTime? EndedAt { get; set; }
        public string ReasonForChange { get; set; }
    }
}
