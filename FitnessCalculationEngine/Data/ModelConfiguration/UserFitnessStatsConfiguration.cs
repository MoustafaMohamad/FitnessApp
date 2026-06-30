using FitnessCalculationEngine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessCalculationEngine.Data.ModelConfiguration
{
    public class UserFitnessStatsConfiguration : IEntityTypeConfiguration<UserFitnessStats>
    {
        public void Configure(EntityTypeBuilder<UserFitnessStats> builder)
        {
            builder.HasKey(x => x.Id);

            // Assuming you are using the Snowflake ID generator for this as well
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(x => x.Gender).WithMany().HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ActivityLevel).WithMany().HasForeignKey(x => x.ActivityLevelId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Goal).WithMany().HasForeignKey(x => x.GoalId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
