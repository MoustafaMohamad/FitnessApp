using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Dtos;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.Exercises.Dtos;

namespace Workout_Exercise_Catalog.Features.Exercises.Queries
{
    public record GetExercisesQuery(int Page = 1, int PageSize = 10) : IRequest<RequestResult<PagedResultDto<ExerciseListItemDto>>>;

    public class GetExercisesQueryHandler : BaseRequestHandler<GetExercisesQuery, RequestResult<PagedResultDto<ExerciseListItemDto>>>
    {

        public GetExercisesQueryHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<PagedResultDto<ExerciseListItemDto>>> Handle(GetExercisesQuery request, CancellationToken cancellationToken)
        {
            var page = request.Page < 1 ? 1 : request.Page;
            var pageSize = request.PageSize < 1 ? 10 : request.PageSize;

            var query = _context.Exercises.AsNoTracking().OrderBy(x => x.Id);
            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ExerciseListItemDto(
                    x.Id,
                    x.Name,
                    x.TargetMuscles,
                    x.EquipmentNeeded,
                    x.Difficulty))
                .ToListAsync(cancellationToken);

            return RequestResult<PagedResultDto<ExerciseListItemDto>>.Success(new PagedResultDto<ExerciseListItemDto>(
                items,
                page,
                pageSize,
                totalCount,
                totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize)));
        }
    }
}
