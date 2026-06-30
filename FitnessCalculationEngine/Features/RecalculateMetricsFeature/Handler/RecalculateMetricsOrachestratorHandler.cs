using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Dto;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Orachestrator;
using FitnessCalculationEngine.Features.Common.Queries;
using FitnessCalculationEngine.Features.RecalculateMetricsFeature.Orachestrator;

namespace FitnessCalculationEngine.Features.RecalculateMetricsFeature.Handler
{
    public class RecalculateMetricsOrachestratorHandler : BaseHandler<RecalculateMetricsOrachestrator, RequestResult<CalculateMetricsResponseDto>>
    {
        public RecalculateMetricsOrachestratorHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<CalculateMetricsResponseDto>> Handle(RecalculateMetricsOrachestrator request, CancellationToken cancellationToken)
        {
            var GetUserStatsQuery = await _mediator.Send(new GetUserStatsQuery(request.UserId));


            if (GetUserStatsQuery.Data != null)
                GetUserStatsQuery.Data.Weight = request.NewWeight;

            var result = await _mediator.Send(new Calculate_Metrics_Orachestrator(request.UserId, GetUserStatsQuery.Data));


            _capPublisher.Publish("RecalculateMetrics", request.UserId);

            return result;
        }
    }
}
