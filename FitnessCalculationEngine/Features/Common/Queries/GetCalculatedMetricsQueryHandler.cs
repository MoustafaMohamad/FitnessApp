using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.ResultPattern;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Features.Common.Queries
{
    public class GetCalculatedMetricsQueryHandler : BaseHandler<GetCalculatedMetricsQuery, RequestResult<CalculatedMetricsDto>>
    {
        public GetCalculatedMetricsQueryHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<CalculatedMetricsDto>> Handle(GetCalculatedMetricsQuery request, CancellationToken cancellationToken)
        {
            var metrics = await _context.CalculatedMetrics
                .Where(x => x.UserId == request.UserId)
                .Select(x => new CalculatedMetricsDto
                {
                    UserId = x.UserId,
                    BMR = x.BMR,
                    TDEE = x.TDEE,
                    CalorieTarget = x.CalorieTarget,
                    StatusName = x.Status.Name
                })
                .FirstOrDefaultAsync(cancellationToken);

            return RequestResult<CalculatedMetricsDto>.Success(metrics);
        }
    }
}
