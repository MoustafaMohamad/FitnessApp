using MediatR;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Dtos;
using Workout_Exercise_Catalog.Features.Common.Queries.Categories;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.Workouts.Dtos;
using Workout_Exercise_Catalog.Common.Helpers;

namespace Workout_Exercise_Catalog.Features.Workouts.Queries
{
    public record GetWorkoutsQuery(
        int Page = 1,
        int PageSize = 10,
        string? Category = null,
        string? Difficulty = null,
        int? Duration = null,
        string? Search = null) : IRequest<RequestResult<PagedResultDto<WorkoutListItemDto>>>;

    public class GetWorkoutsQueryHandler : BaseRequestHandler<GetWorkoutsQuery, RequestResult<PagedResultDto<WorkoutListItemDto>>>
    {

        public GetWorkoutsQueryHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<PagedResultDto<WorkoutListItemDto>>> Handle(GetWorkoutsQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.Category))
            {
                var categoryExists = await _mediator.Send(new IsCategoryExistQuery(request.Category), cancellationToken);
                if (!categoryExists.Data)
                {
                    return RequestResult<PagedResultDto<WorkoutListItemDto>>.Failure(ErrorCode.VAL_REQUIRED_FIELD, "Invalid category filter value.");
                }
            }

            var page = request.Page < 1 ? 1 : request.Page;
            var pageSize = request.PageSize < 1 ? 10 : request.PageSize;

            var query = _context.Workouts
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Category))
            {
                var category = request.Category.Trim().ToLower();
                query = query.Where(x => x.Category.Name.ToLower() == category);
            }

            if (!string.IsNullOrWhiteSpace(request.Difficulty))
            {
                var difficulty = request.Difficulty.Trim().ToLower();
                query = query.Where(x => x.Difficulty.ToLower() == difficulty);
            }

            if (request.Duration.HasValue)
            {
                query = query.Where(x => x.DurationInMinutes == request.Duration.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim().ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(search) || x.WorkoutPlan.Name.ToLower().Contains(search));
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query
                .OrderBy(x => x.OrderIndex)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Map<WorkoutListItemDto>()
                .ToListAsync(cancellationToken);

            var result = new PagedResultDto<WorkoutListItemDto>(
                items,
                page,
                pageSize,
                totalCount,
                totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize));

            return RequestResult<PagedResultDto<WorkoutListItemDto>>.Success(result);
        }
    }
}
