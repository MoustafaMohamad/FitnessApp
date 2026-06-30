using FitnessCalculationEngine.Common.ResultPattern;
using FluentValidation;
using MediatR;

namespace FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query
{
    public class PlanConfigDto
    {
        public long Id { get; set; }
        public string Goal { get; set; }
        public string Status { get; set; }
        public double CalorieMin { get; set; }
        public double CalorieMax { get; set; }
        public string ExternalPlanId { get; set; }
        public string PlanName { get; set; }
        public int WorkoutsPerWeek { get; set; }
    }

    public record GetPlanConfigsQuery(
        string? Goal,
        string? Status,
        int Page = 1,
        int PageSize = 20
    ) : IRequest<PagedResult<PlanConfigDto>>;

    public class GetPlanConfigsQueryValidator : AbstractValidator<GetPlanConfigsQuery>
    {
        public GetPlanConfigsQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1).WithMessage("Page must be at least 1.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100).WithMessage("PageSize must be between 1 and 100.");
        }
    }
}
