using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Common.Exceptions;
using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Entities;
using FitnessCalculationEngine.Features.CalculatedMetricsFeature.Command;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Dto;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Orachestrator;
using FitnessCalculationEngine.Features.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Features.CalculatedMetricsFeature.Handler
{
    public class CalculateMetricsOrachestratorHandler : BaseHandler<CalculateMetricsOrachestrator, RequestResult<CalculateMetricsResponseDto>>
    {
        public CalculateMetricsOrachestratorHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<CalculateMetricsResponseDto>> Handle(CalculateMetricsOrachestrator request, CancellationToken cancellationToken)
        {

            var GetUserStatsQuery = await _mediator.Send(new GetUserStatsQuery(request.UserId), cancellationToken);

            var result = await _mediator.Send(new Calculate_Metrics_Orachestrator(request.UserId, GetUserStatsQuery.Data), cancellationToken);
           
            return result;
        }
    }
}
