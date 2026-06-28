using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workout_Exercise_Catalog.Entities;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
       // builder.HasKey(x => x.Id);

       // builder.HasIndex(x => x.Category);
        builder.HasIndex(x => new { x.WorkoutPlanId, x.OrderIndex,x.CategoryId });

        builder.HasOne(x => x.WorkoutPlan)
            .WithMany(x => x.Workouts)
            .HasForeignKey(x => x.WorkoutPlanId);
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Workouts)
            .HasForeignKey(x => x.CategoryId);
    }
}

