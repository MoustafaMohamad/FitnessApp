using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workout_Exercise_Catalog.Entities;

public class WorkoutSessionConfiguration : IEntityTypeConfiguration<WorkoutSession>
{
    public void Configure(EntityTypeBuilder<WorkoutSession> builder)
    {
        //builder.HasKey(x => x.SessionId);

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => new { x.UserId, x.WorkoutId, x.Status });

        builder.HasOne(x => x.Workout)
            .WithMany(x => x.WorkoutSessions)
            .HasForeignKey(x => x.WorkoutId);
    }
}
