using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Common.Exceptions;
using FitnessCalculationEngine.Common.ResultPattern;
using FitnessCalculationEngine.Entities;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Dto;
using FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Orachestrator;
using MediatR.Wrappers;

namespace FitnessCalculationEngine.Features.Common.CalculateMetricsOrachestrator.Handler
{
    public class CalculateMetricsOrachestratorHandler : BaseHandler<Calculate_Metrics_Orachestrator, RequestResult<CalculateMetricsResponseDto>>
    {
        public CalculateMetricsOrachestratorHandler(BaseParameters parameters) : base(parameters)
        {

        }
        public override async Task<RequestResult<CalculateMetricsResponseDto>> Handle(Calculate_Metrics_Orachestrator request, CancellationToken cancellationToken)
        {
            if (request.UserStatsDto == null)
                throw new BusinessException(ErrorCode.BadRequest, "FCE_STATS_NOT_FOUND");

            double bmr = 0;
            if (request.UserStatsDto.GenderEnumId == LookupEnum.Male)
                bmr = (10 * request.UserStatsDto.Weight) + (6.25 * request.UserStatsDto.Height) - (5 * request.UserStatsDto.Age) + 5;
            else if (request.UserStatsDto.GenderEnumId == LookupEnum.Female)
                bmr = (10 * request.UserStatsDto.Weight) + (6.25 * request.UserStatsDto.Height) - (5 * request.UserStatsDto.Age) - 161;
            else
                throw new BusinessException(ErrorCode.BadRequest, "FCE_INVALID_GENDER");


            double tdee = bmr * request.UserStatsDto.ActivityFactor;

            double calorieTarget = tdee + request.UserStatsDto.CalorieOffset;

            if (!double.IsFinite(bmr) || !double.IsFinite(tdee) || !double.IsFinite(calorieTarget))
                throw new BusinessException(ErrorCode.InvalidInput, "FCE_INVALID_CALCULATION");


            LookupEnum status;
            if (calorieTarget <= 1800)
                status = LookupEnum.Weak;
            else if (calorieTarget <= 2500)
                status = LookupEnum.Normal;
            else
                status = LookupEnum.Hard;



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



            return RequestResult<CalculateMetricsResponseDto>.Success(new CalculateMetricsResponseDto
            {
                BMR = bmr,
                TDEE = tdee,
                CalorieTarget = calorieTarget,
                Status = status
            });
        }
    }
}
