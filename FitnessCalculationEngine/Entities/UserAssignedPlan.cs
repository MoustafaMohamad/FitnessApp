using System;

namespace FitnessCalculationEngine.Entities
{
    public class UserAssignedPlan:BaseInformation
    {
        public long UserId { get; set; }

        public string ExternalPlanId { get; set; }

    }
}
