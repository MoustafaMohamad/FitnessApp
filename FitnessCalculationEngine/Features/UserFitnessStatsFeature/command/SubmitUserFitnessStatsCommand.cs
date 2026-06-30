using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Common.Interface;
using FluentValidation;
using MediatR;
using System.Windows.Input;

namespace FitnessCalculationEngine.Features.UserFitnessStatsFeature.command
{
    public record SubmitUserFitnessStatsCommand(
        double Weight, 
        double Height, 
        int Age, 
        LookupEnum Gender, 
        LookupEnum Goal, 
        LookupEnum ActivityLevel) : ICommand<bool>;

    public class SubmitUserFitnessStatsCommandValidator : AbstractValidator<SubmitUserFitnessStatsCommand>
    {
        public SubmitUserFitnessStatsCommandValidator()
        {
            RuleFor(x => x.Age)
                .InclusiveBetween(16, 100).WithMessage("Age must be between 16 and 100 years. Age outside the allowed range.");

            RuleFor(x => x.Weight)
                .InclusiveBetween(40.0, 200.0).WithMessage("Weight must be between 40 and 200 kg. Weight outside the allowed range.");

            RuleFor(x => x.Height)
                .InclusiveBetween(140.0, 220.0).WithMessage("Height must be between 140 and 220 cm. Height outside the allowed range.");

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("GenderId is required.");
            RuleFor(x => x.Goal)
                .IsInEnum().WithMessage("GoalId is required.");
            RuleFor(x => x.ActivityLevel)
                .IsInEnum().WithMessage("ActivityLevelId is required.");
        }
    }
}
