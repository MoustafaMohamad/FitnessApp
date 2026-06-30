using DotNetCore.CAP;
using FitnessCalculationEngine.Features.UserAssignedPlanFeature.Command;
using FitnessCalculationEngine.Features.UserAssignedPlanFeature.EndPoint;
using MediatR;

namespace FitnessCalculationEngine.CapConsumers
{
    public class ReCalculatedFitnessStatsEventHandler : ICapSubscribe
    {
        IMediator _mediator;
        public ReCalculatedFitnessStatsEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        [CapSubscribe("RecalculateMetrics.create", Group = "CalculatedFitnessStats")]
        public async Task HandleReCalculatedFitnessStatsEvent(long userId)
        {
            await _mediator.Send(new AssignFitnessPlanOrachestrator(userId));
        }
    }
}
