using FitnessCalculationEngine.Common.Interface;
using FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query;
using FluentValidation;

namespace FitnessCalculationEngine.Features.UserAssignedPlanFeature.Command
{
    public record AssignFitnessPlanOrachestrator(long UserId) : ICommand<PlanConfigDto>;

    public class AssignFitnessPlanCommandValidator : AbstractValidator<AssignFitnessPlanOrachestrator>
    {
        public AssignFitnessPlanCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId is required and must be valid.");
        }
    }
}
