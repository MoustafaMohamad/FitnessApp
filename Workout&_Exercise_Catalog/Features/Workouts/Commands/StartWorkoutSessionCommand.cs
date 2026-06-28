using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Workout_Exercise_Catalog.Common;
using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Entities;
using Workout_Exercise_Catalog.Features.Common;
using Workout_Exercise_Catalog.Features.Common.Data;
using Workout_Exercise_Catalog.Features.Common.Dtos;
using Workout_Exercise_Catalog.Features.Common.Views;
using Workout_Exercise_Catalog.Features.WorkoutPlans.Dtos;
using Workout_Exercise_Catalog.Features.WorkoutPlans.Queries;
using Workout_Exercise_Catalog.Features.Workouts.Dtos;

namespace Workout_Exercise_Catalog.Features.Workouts.Commands
{
    public record StartWorkoutSessionCommand(
        int WorkoutId,
        string? Difficulty,
        int? PlannedDuration) : IRequest<RequestResult<StartWorkoutSessionDto>>; //IRequest<RequestResult<StartWorkoutSessionDto>>;

    public class StartWorkoutSessionCommandHandler : BaseRequestHandler<StartWorkoutSessionCommand, RequestResult<StartWorkoutSessionDto>>//IRequestHandler<StartWorkoutSessionCommand, RequestResult<StartWorkoutSessionDto>>
    {
        private const string ActiveStatus = "Active";


        public StartWorkoutSessionCommandHandler( RequestParameters requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<StartWorkoutSessionDto>> Handle(StartWorkoutSessionCommand request, CancellationToken cancellationToken)
        {
            var workoutExists = await _context.Workouts.AnyAsync(x => x.Id == request.WorkoutId, cancellationToken);
            if (!workoutExists)
            {
                return RequestResult<StartWorkoutSessionDto>.Failure(ErrorCode.RES_WORKOUT_NOT_FOUND);
            }

            var userId = GetCurrentUserId();
            var session = await _context.WorkoutSessions
                .FirstOrDefaultAsync(
                    x => x.UserId == userId && x.WorkoutId == request.WorkoutId && x.Status == ActiveStatus,
                    cancellationToken);

            if (session is null)
            {
                var random = new Random();

                long number = ((long)random.Next() << 32) | (uint)random.Next();
                session = new WorkoutSession
                {
                    Id = number,
                    UserId = userId,
                    WorkoutId = request.WorkoutId,
                    StartedAt = DateTime.UtcNow,
                    Status = ActiveStatus
                };

                await _context.WorkoutSessions.AddAsync(session, cancellationToken);
            }

            var exercises = await _context.WorkoutExercises
                .AsNoTracking()
                .Where(x => x.WorkoutId == request.WorkoutId)
                .OrderBy(x => x.OrderIndex)
                    .Map<WorkoutExerciseDto>()
                .ToListAsync(cancellationToken);

            return RequestResult<StartWorkoutSessionDto>.Success(new StartWorkoutSessionDto(session.Id, exercises));
        }

        //public override Task<RequestResult<StartWorkoutSessionDto>> Handle(StartWorkoutSessionCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        private int GetCurrentUserId()
        {
            if (_userState.ID == Guid.Empty)
            {
                return 0;
            }

            return Math.Abs(_userState.ID.GetHashCode());
        }
    }
}
