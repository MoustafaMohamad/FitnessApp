using FitnessCalculationEngine.Common.ResultPattern;
using MediatR;

namespace FitnessCalculationEngine.Features.Common.Queries
{
    public class CalculatedMetricsDto
    {
        public long UserId { get; set; }
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public double CalorieTarget { get; set; }
        public string StatusName { get; set; }
    }

    public record GetCalculatedMetricsQuery(long UserId) : IRequest<RequestResult<CalculatedMetricsDto>>;
}
