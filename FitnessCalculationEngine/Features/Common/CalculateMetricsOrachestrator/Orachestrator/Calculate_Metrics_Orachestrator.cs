using FitnessCalculationEngine.Common.Interface;
using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Dto;
using FitnessCalculationEngine.Features.Common.Queries;

namespace FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Orachestrator
{
    public record Calculate_Metrics_Orachestrator(long UserId, UserStatsDto UserStatsDto) : ICommand<RequestResult<CalculateMetricsResponseDto>>;
    
}
