using Workout_Exercise_Catalog.Entities;

namespace Workout_Exercise_Catalog.Entities;

public class WorkoutExercise : BaseEntity
{
   // public int Id { get; set; }

    public int WorkoutId { get; set; }

    public int ExerciseId { get; set; }

    public int OrderIndex { get; set; }

    public int SetsDefault { get; set; }

    public string RepsDefault { get; set; } = null!;

    public int RestTimeInSeconds { get; set; }

    public Workout Workout { get; set; } = null!;

    public Exercise Exercise { get; set; } = null!;
}