namespace Workout_Exercise_Catalog.Entities;

public class Exercise : BaseEntity
{
    //public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string VideoUrl { get; set; } = null!;

    public string TargetMuscles { get; set; } = null!;
    // ممكن تخزنها JSON

    public string EquipmentNeeded { get; set; } = null!;
    // ممكن تخزنها JSON

    public string Difficulty { get; set; } = null!;

    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = null;
}