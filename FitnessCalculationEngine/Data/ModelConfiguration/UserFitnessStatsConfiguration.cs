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

            // Map the enums as strings in the database instead of integers
            builder.Property(x => x.Gender).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.ActivityLevel).HasConversion<string>().HasMaxLength(20);

            builder.Property(x => x.Goal).HasConversion<string>().HasMaxLength(50);
        }
    }
}
