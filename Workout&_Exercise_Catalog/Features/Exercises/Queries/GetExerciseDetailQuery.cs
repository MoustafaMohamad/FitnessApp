using MediatR;
using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.Exercises.Dtos;

namespace Workout_Exercise_Catalog.Features.Exercises.Queries
{
    public record GetExerciseDetailQuery(int Id) : IRequest<RequestResult<ExerciseDetailDto>>;

    public class GetExerciseDetailQueryHandler : BaseRequestHandler<GetExerciseDetailQuery, RequestResult<ExerciseDetailDto>>
    {

        public GetExerciseDetailQueryHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<ExerciseDetailDto>> Handle(GetExerciseDetailQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercises
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Map <ExerciseDetailDto>()
                .FirstOrDefaultAsync(cancellationToken);

            return exercise is null
                ? RequestResult<ExerciseDetailDto>.Failure(ErrorCode.RES_EXERCISE_NOT_FOUND)
                : RequestResult<ExerciseDetailDto>.Success(exercise);
        }
    }
}
