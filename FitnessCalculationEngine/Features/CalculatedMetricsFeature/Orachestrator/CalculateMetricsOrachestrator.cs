using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Common.Interface;
using FluentValidation;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Dto;

namespace FitnessCalculationEngine.Features.CalculatedMetricsFeature.Command
{
    public record CalculateMetricsOrachestrator(long UserId) : ICommand<RequestResult<CalculateMetricsResponseDto>>;

    public class CalculateMetricsCommandValidator : AbstractValidator<CalculateMetricsOrachestrator>
    {
        public CalculateMetricsCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId is required and must be valid.");
        }
    }
}
