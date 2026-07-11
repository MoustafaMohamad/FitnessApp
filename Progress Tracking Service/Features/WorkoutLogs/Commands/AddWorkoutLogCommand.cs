using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Progress_Tracking_Service.Entities;
using ProgressTrackingService.Common.BaseHandler;
using ProgressTrackingService.Common.Enums;
using ProgressTrackingService.Common.Interface;
using ProgressTrackingService.Common.ResultPattern;
using ProgressTrackingService.Features.Common.AppLogs.Commands;
using ProgressTrackingService.Features.WorkoutLogs.Dtos;

namespace ProgressTrackingService.Features.WorkoutLogs.Commands;

public sealed record AddWorkoutLogCommand(AddWorkoutLogRequestDto Data) : ICommand<RequestResult<WorkoutLogDto>>;

public sealed class AddWorkoutLogCommandValidator : AbstractValidator<AddWorkoutLogCommand>
{
    public AddWorkoutLogCommandValidator()
    {
        RuleFor(command => command.Data.SessionId).NotEmpty().MaximumLength(200);
        RuleFor(command => command.Data.WorkoutId).GreaterThan(0);
        RuleFor(command => command.Data.Duration).GreaterThanOrEqualTo(0);
        RuleFor(command => command.Data.CaloriesBurned).GreaterThanOrEqualTo(0);
        RuleFor(command => command.Data.Rating).InclusiveBetween(1, 5);
        RuleFor(command => command.Data.CompletedAt).NotEmpty();
        RuleFor(command => command.Data.ExercisesCompleted).NotEmpty();
        RuleForEach(command => command.Data.ExercisesCompleted).ChildRules(exercise =>
        {
            exercise.RuleFor(item => item.ExerciseId).GreaterThan(0);
            exercise.RuleFor(item => item.Sets).GreaterThanOrEqualTo(0);
            exercise.RuleFor(item => item.Reps).GreaterThanOrEqualTo(0);
            exercise.RuleFor(item => item.WeightUsed).GreaterThanOrEqualTo(0);
        });
    }
}

public sealed class AddWorkoutLogCommandHandler : BaseHandler<AddWorkoutLogCommand, RequestResult<WorkoutLogDto>>
{
    private readonly IMapper _mapper;

    public AddWorkoutLogCommandHandler(BaseParameters baseParameters, IMapper mapper) : base(baseParameters)
    {
        _mapper = mapper;
    }

    public override async Task<RequestResult<WorkoutLogDto>> Handle(AddWorkoutLogCommand request, CancellationToken cancellationToken)
    {
        var workoutLog = _mapper.Map<WorkoutLog>(request.Data);
        workoutLog.Id = _snowflake.CreateId();
        workoutLog.UserId = _currentUserService.UserId;
        workoutLog.Exercises = request.Data.ExercisesCompleted.Select(exercise =>
        {
            var entity = _mapper.Map<WorkoutLogExercise>(exercise);
            entity.Id = _snowflake.CreateId();
            entity.WorkoutLogId = workoutLog.Id;
            return entity;
        }).ToList();

        var statistics = await _context.UserStatisticss.AsTracking()
            .SingleOrDefaultAsync(item => item.Id == workoutLog.UserId, cancellationToken);
        if (statistics is null)
        {
            statistics = new UserStatistics { Id = workoutLog.UserId };
            _context.UserStatisticss.Add(statistics);
        }
        statistics.TotalWorkouts++;
        statistics.TotalCaloriesBurned += workoutLog.CaloriesBurned;

        var streak = await _context.Streaks.AsTracking()
            .SingleOrDefaultAsync(item => item.UserId == workoutLog.UserId, cancellationToken);
        if (streak is null)
        {
            streak = new Streak { Id = _snowflake.CreateId(), UserId = workoutLog.UserId };
            _context.Streaks.Add(streak);
        }
        var workoutDate = workoutLog.CompletedAt.Date;
        if (streak.LastWorkoutDate is null || workoutDate > streak.LastWorkoutDate.Value.Date)
        {
            streak.CurrentStreak = streak.LastWorkoutDate?.Date == workoutDate.AddDays(-1)
                ? streak.CurrentStreak + 1
                : 1;
            streak.LongestStreak = Math.Max(streak.LongestStreak, streak.CurrentStreak);
            streak.LastWorkoutDate = workoutDate;
        }

        await _context.WorkoutLogs.AddAsync(workoutLog, cancellationToken);
        await _mediator.Send(new AddLogCommand(LogLevels.Information,
            $"Workout log {workoutLog.Id} was added for user {workoutLog.UserId}."), cancellationToken);
        await _capPublisher.PublishAsync("workout_completed", new { workoutLog.Id, workoutLog.UserId, streak.CurrentStreak }, cancellationToken: cancellationToken);

        return RequestResult<WorkoutLogDto>.Success(_mapper.Map<WorkoutLogDto>(workoutLog), "Workout log added successfully.");
    }
}
