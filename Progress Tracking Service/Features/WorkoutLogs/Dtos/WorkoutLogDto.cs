namespace ProgressTrackingService.Features.WorkoutLogs.Dtos;

public sealed class WorkoutLogDto
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public long WorkoutId { get; init; }
    public string SessionId { get; init; } = string.Empty;
    public int DurationInMinutes { get; init; }
    public int CaloriesBurned { get; init; }
    public int Rating { get; init; }
    public string? Notes { get; init; }
    public DateTime CompletedAt { get; init; }
    public IReadOnlyCollection<WorkoutLogExerciseDto> Exercises { get; init; } = Array.Empty<WorkoutLogExerciseDto>();
}

public sealed class WorkoutLogExerciseDto
{
    public long ExerciseId { get; init; }
    public int SetsCompleted { get; init; }
    public int RepsCompleted { get; init; }
    public double WeightUsed { get; init; }
    public bool Completed { get; init; }
}
