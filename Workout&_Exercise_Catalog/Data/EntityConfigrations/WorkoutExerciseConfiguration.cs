using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workout_Exercise_Catalog.Entities;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
      //  builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Workout)
            .WithMany(x => x.WorkoutExercises)
            .HasForeignKey(x => x.WorkoutId);

        builder.HasOne(x => x.Exercise)
            .WithMany(x => x.WorkoutExercises)
            .HasForeignKey(x => x.ExerciseId);
    }
}