
using FitnessCalculationEngine.Common.Enums;

namespace FitnessCalculationEngine.Features.UserFitnessStatsFeature.ViewModels
{


    public class SubmitUserFitnessStatsViewModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public LookupEnum GenderId { get; set; }
        public LookupEnum GoalId { get; set; }
        public LookupEnum ActivityLevelId { get; set; }
    }
}
