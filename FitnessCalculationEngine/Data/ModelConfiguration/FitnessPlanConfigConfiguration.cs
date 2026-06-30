using FitnessCalculationEngine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessCalculationEngine.Data.ModelConfiguration
{
    public class FitnessPlanConfigConfiguration : IEntityTypeConfiguration<FitnessPlanConfig>
    {
        public void Configure(EntityTypeBuilder<FitnessPlanConfig> builder)
        {
            builder.HasKey(x => x.Id);

            // Using Snowflake ID generator - ID will be assigned manually before saving
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Status).HasMaxLength(20);
            builder.Property(x => x.Goal).HasMaxLength(50);
            builder.Property(x => x.ExternalPlanId).HasMaxLength(50);
            builder.Property(x => x.PlanName).HasMaxLength(100);
        }
    }
}
