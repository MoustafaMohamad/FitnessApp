using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workout_Exercise_Catalog.Entities;

public class WorkoutPlanConfiguration : IEntityTypeConfiguration<WorkoutPlan>
{
    public void Configure(EntityTypeBuilder<WorkoutPlan> builder)
    {
        //builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.ExternalPlanId).IsUnique();

        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Goal).HasMaxLength(50);
        builder.Property(x => x.Status).HasMaxLength(20);
        builder.Property(x => x.Difficulty).HasMaxLength(20);
    }
}