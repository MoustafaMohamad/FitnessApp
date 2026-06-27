using FitnessCalculationEngine.Common.Enums;
using FluentValidation;

namespace FitnessCalculationEngine.Features.UserFitnessStatsFeature.ViewModels
{


    public class SubmitUserFitnessStatsViewModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Goal Goal { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
    }
}
