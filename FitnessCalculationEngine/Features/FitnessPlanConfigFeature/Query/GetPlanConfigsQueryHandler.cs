using FitnessCalculationEngine.Common.BaseHandler;
using FitnessCalculationEngine.Common.ResultPattern;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Features.FitnessPlanConfigFeature.Query
{
    public class GetPlanConfigsQueryHandler : BaseHandler<GetPlanConfigsQuery, PagedResult<PlanConfigDto>>
    {
        public GetPlanConfigsQueryHandler(BaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<PagedResult<PlanConfigDto>> Handle(GetPlanConfigsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.FitnessPlanConfigs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Goal))
                query = query.Where(x => x.Goal.ToLower() == request.Goal.ToLower());

            if (!string.IsNullOrWhiteSpace(request.Status))
                query = query.Where(x => x.Status.ToLower() == request.Status.ToLower());

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(x => x.Id)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PlanConfigDto
                {
                    Id = x.Id,
                    Goal = x.Goal,
                    Status = x.Status,
                    CalorieMin = x.CalorieMin,
                    CalorieMax = x.CalorieMax,
                    ExternalPlanId = x.ExternalPlanId,
                    PlanName = x.PlanName,
                    WorkoutsPerWeek = x.WorkoutsPerWeek
                })
                .ToListAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            return new PagedResult<PlanConfigDto>(items, request.Page, request.PageSize, totalCount, totalPages);
        }
    }
}
