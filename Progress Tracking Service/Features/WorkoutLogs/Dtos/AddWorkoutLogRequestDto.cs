namespace ProgressTrackingService.Features.WorkoutLogs.Dtos;

public sealed class AddWorkoutLogRequestDto
{
    public long WorkoutId { get; init; }
    public string SessionId { get; init; } = string.Empty;
    public int Duration { get; init; }
    public int CaloriesBurned { get; init; }
    public int Rating { get; init; }
    public string? Notes { get; init; }
    public string? Difficulty { get; init; }
    public DateTime CompletedAt { get; init; }
    public IReadOnlyCollection<AddWorkoutLogExerciseDto> ExercisesCompleted { get; init; } = Array.Empty<AddWorkoutLogExerciseDto>();
}

public sealed class AddWorkoutLogExerciseDto
{
    public long ExerciseId { get; init; }
    public int Sets { get; init; }
    public int Reps { get; init; }
    public double WeightUsed { get; init; }
    public bool Completed { get; init; }
}
