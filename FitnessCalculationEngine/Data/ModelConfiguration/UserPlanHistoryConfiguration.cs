using FitnessCalculationEngine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessCalculationEngine.Data.ModelConfiguration
{
    public class UserPlanHistoryConfiguration : IEntityTypeConfiguration<UserPlanHistory>
    {
        public void Configure(EntityTypeBuilder<UserPlanHistory> builder)
        {
            builder.HasKey(x => x.Id);

            // Since you are using a Snowflake ID generator, we prevent the DB from auto-generating it
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.ExternalPlanId).HasMaxLength(50);
            builder.Property(x => x.ReasonForChange).HasMaxLength(250);
        }
    }
}
