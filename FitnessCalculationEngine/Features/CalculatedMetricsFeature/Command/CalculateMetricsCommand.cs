using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.CalculatedMetricsFeature.ViewModels;
using FitnessCalculationEngine.Common.Interface;
using FluentValidation;

namespace FitnessCalculationEngine.Features.CalculatedMetricsFeature.Command
{
    public record CalculateMetricsCommand(long UserId) : ICommand<CalculateMetricsResponseViewModel>;

    public class CalculateMetricsCommandValidator : AbstractValidator<CalculateMetricsCommand>
    {
        public CalculateMetricsCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId is required and must be valid.");
        }
    }
}
