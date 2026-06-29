using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.Exceptions;
using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Entities;
using FitnessCalculationEngine.Features.CalculatedMetricsFeature.Command;
using FitnessCalculationEngine.Features.CalculatedMetricsFeature.ViewModels;
using FitnessCalculationEngine.Features.Common.Data;
using Microsoft.EntityFrameworkCore;
using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Features.Common.Queries;

namespace FitnessCalculationEngine.Features.CalculatedMetricsFeature.Handler
{
    public class CalculateMetricsHandler : BaseHandler<CalculateMetricsCommand, CalculateMetricsResponseViewModel>
    {
        public CalculateMetricsHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<CalculateMetricsResponseViewModel> Handle(CalculateMetricsCommand request, CancellationToken cancellationToken)
        {
            var userStats = await _mediator.Send(new GetUserStatsQuery(request.UserId), cancellationToken);

            if (userStats.Data == null)
                throw new BusinessException(ErrorCode.BadRequest, "FCE_STATS_NOT_FOUND");

            double bmr = 0;
            if (userStats.Data.GenderEnumId == LookupEnum.Male)
                bmr = (10 * userStats.Data.Weight) + (6.25 * userStats.Data.Height) - (5 * userStats.Data.Age) + 5;
            else if (userStats.Data.GenderEnumId == LookupEnum.Female)
                bmr = (10 * userStats.Data.Weight) + (6.25 * userStats.Data.Height) - (5 * userStats.Data.Age) - 161;
            else
                throw new BusinessException(ErrorCode.BadRequest, "FCE_INVALID_GENDER");


            double tdee = bmr * userStats.Data.ActivityFactor;

            double calorieTarget = tdee + userStats.Data.CalorieOffset;

            if (!double.IsFinite(bmr) || !double.IsFinite(tdee) || !double.IsFinite(calorieTarget))
                throw new BusinessException(ErrorCode.InvalidInput, "FCE_INVALID_CALCULATION");


            long status;
            if (calorieTarget <= 1800)
                status = await _enumLookupCache.GetLookupId(LookupEnum.Weak);
            else if (calorieTarget <= 2500)
                status = await _enumLookupCache.GetLookupId(LookupEnum.Normal);
            else
                status = await _enumLookupCache.GetLookupId(LookupEnum.Hard);



            var calculatedMetrics = new CalculatedMetrics
            {
                Id = _snowflake.CreateId(),
                UserId = request.UserId,
                BMR = bmr,
                TDEE = tdee,
                CalorieTarget = calorieTarget,
                StatusId = status
            };
            await _context.CalculatedMetrics.AddAsync(calculatedMetrics, cancellationToken);



            return new CalculateMetricsResponseViewModel
            {
                BMR = bmr,
                TDEE = tdee,
                CalorieTarget = calorieTarget,
                StatusId = status
            };
        }
    }
}
