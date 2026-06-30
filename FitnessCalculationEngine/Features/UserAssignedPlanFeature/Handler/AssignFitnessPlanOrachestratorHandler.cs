using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Common.Exceptions;
using FitnessCalculationEngine.Entities;
using FitnessCalculationEngine.Features.Common.Queries;
using FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query;
using FitnessCalculationEngine.Features.UserAssignedPlanFeature.Command;
using FitnessCalculationEngine.Features.UserAssignedPlanFeature.Queries.GetAssignedPlan;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Features.UserAssignedPlanFeature.Handler
{
    public class AssignFitnessPlanOrachestratorHandler : BaseHandler<AssignFitnessPlanOrachestrator, PlanConfigDto>
    {
        public AssignFitnessPlanOrachestratorHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<PlanConfigDto> Handle(AssignFitnessPlanOrachestrator request, CancellationToken cancellationToken)
        {
            var userStatsResult = await _mediator.Send(new GetUserStatsQuery(request.UserId), cancellationToken);
            if (userStatsResult.Data == null)
            {
                throw new BusinessException(ErrorCode.BadRequest, "FCE_STATS_NOT_FOUND");
            }

            var metricsResult = await _mediator.Send(new GetCalculatedMetricsQuery(request.UserId), cancellationToken);
            if (metricsResult.Data == null)
            {
                throw new BusinessException(ErrorCode.BadRequest, "FCE_METRICS_NOT_CALCULATED");
            }

            var planConfigResult = await _mediator.Send(new GetMatchingPlanConfigQuery(userStatsResult.Data.GoalName, metricsResult.Data.StatusName), cancellationToken);
            var targetPlan = planConfigResult.Data;

            if (targetPlan == null)
            {
                throw new BusinessException(ErrorCode.BadRequest, "FCE_NO_MATCHING_PLAN");
            }

            var existingPlan = await _mediator.Send(new GetAssignedPlanQuery(request.UserId), cancellationToken);

            if (existingPlan.Data != null)
            {
                existingPlan.Data.IsActive = false;

                var history = new UserPlanHistory
                {
                    Id = _snowflake.CreateId(),
                    UserId = request.UserId,
                    ExternalPlanId = existingPlan.Data.ExternalPlanId,
                    EndedAt = DateTime.UtcNow,
                    ReasonForChange = "Reassigned"
                };
                await _context.UserPlanHistories.AddAsync(history, cancellationToken);
            }

            var newAssignment = new UserAssignedPlan
            {
                Id = _snowflake.CreateId(),
                UserId = request.UserId,
                ExternalPlanId = targetPlan.ExternalPlanId,
                IsActive = true
            };
            await _context.UserAssignedPlans.AddAsync(newAssignment, cancellationToken);


            return targetPlan;
        }
    }
}
