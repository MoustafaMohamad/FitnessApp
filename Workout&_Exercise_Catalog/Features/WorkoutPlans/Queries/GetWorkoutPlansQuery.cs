using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Dtos;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.WorkoutPlans.Dtos;

namespace Workout_Exercise_Catalog.Features.WorkoutPlans.Queries
{
    public record GetWorkoutPlansQuery(int Page = 1, int PageSize = 10) : IRequest<RequestResult<PagedResultDto<WorkoutPlanListItemDto>>>;

    public class GetWorkoutPlansQueryHandler : BaseRequestHandler<GetWorkoutPlansQuery, RequestResult<PagedResultDto<WorkoutPlanListItemDto>>>
    {

        public GetWorkoutPlansQueryHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<PagedResultDto<WorkoutPlanListItemDto>>> Handle(GetWorkoutPlansQuery request, CancellationToken cancellationToken)
        {
            var page = request.Page < 1 ? 1 : request.Page;
            var pageSize = request.PageSize < 1 ? 10 : request.PageSize;

            var query = _context.WorkoutPlans.AsNoTracking().OrderBy(x => x.Id);
            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new WorkoutPlanListItemDto(
                    x.Id,
                    x.ExternalPlanId,
                    x.Name,
                    x.Goal,
                    x.Status,
                    x.Difficulty))
                .ToListAsync(cancellationToken);

            return RequestResult<PagedResultDto<WorkoutPlanListItemDto>>.Success(new PagedResultDto<WorkoutPlanListItemDto>(
                items,
                page,
                pageSize,
                totalCount,
                totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize)));
        }
    }
}
