using FitnessCalculationEngine.Common.Interface;
using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Dto;
using FluentValidation;

namespace FitnessCalculationEngine.Features.RecalculateMetricsFeature.Orachestrator
{
    

    public record RecalculateMetricsOrachestrator(long UserId, double NewWeight, string? Reason) : ICommand<RequestResult<CalculateMetricsResponseDto>>;

    public class RecalculateMetricsCommandValidator : AbstractValidator<RecalculateMetricsOrachestrator>
    {
        public RecalculateMetricsCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId is required and must be valid.");
            
            RuleFor(x => x.NewWeight)
                .GreaterThan(0).WithMessage("NewWeight must be greater than 0.");
        }
    }
}
