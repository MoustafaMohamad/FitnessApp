namespace ProgressTrackingService.Features.Progress.Dtos;

public sealed class AddWeightRequestDto
{
    public double Weight { get; init; }
    public DateTime Date { get; init; }
    public string? Notes { get; init; }
}

public sealed class WeightHistoryDto
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public double Weight { get; init; }
    public DateTime Date { get; init; }
    public string? Notes { get; init; }
}

public sealed class UserStatisticsDto
{
    public long UserId { get; init; }
    public int TotalWorkouts { get; init; }
    public int TotalCaloriesBurned { get; init; }
    public double CurrentWeight { get; init; }
    public double StartWeight { get; init; }
    public double TotalWeightLost { get; init; }
    public DateTime? UpdatedAt { get; init; }
}

public sealed class StreakDto
{
    public int CurrentStreak { get; init; }
    public int LongestStreak { get; init; }
    public DateTime? LastWorkoutDate { get; init; }
}

public sealed class ProgressSummaryDto
{
    public long UserId { get; init; }
    public int CompletedWorkouts { get; init; }
    public int CaloriesBurned { get; init; }
    public double? CurrentWeight { get; init; }
    public StreakDto? Streak { get; init; }
}

public sealed class AchievementDto
{
    public long Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string IconUrl { get; init; } = string.Empty;
    public DateTime EarnedAt { get; init; }
}
