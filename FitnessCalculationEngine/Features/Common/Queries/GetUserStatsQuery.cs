using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Common.ResultPattern;
using MediatR;

namespace FitnessCalculationEngine.Features.Common.Queries
{
    public class UserStatsDto
    {
        public long UserId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public LookupEnum GenderEnumId { get; set; }
        public double ActivityFactor { get; set; }
        public double CalorieOffset { get; set; }
    }

    public record GetUserStatsQuery(long UserId) : IRequest<RequestResult<UserStatsDto>>;
}
