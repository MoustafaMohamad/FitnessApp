using FitnessCalculationEngine.Common.Enums;
using FitnessCalculationEngine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessCalculationEngine.Data.ModelConfiguration
{
    public class LookupConfiguration : IEntityTypeConfiguration<Lookup>
    {
        public void Configure(EntityTypeBuilder<Lookup> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedNever();
            builder.Property(l => l.Name).IsRequired().HasMaxLength(50);
            builder.Property(l => l.Value).IsRequired();

        
            builder.HasData(
                // Gender (CategoryId = 100000000000000001)
                new Lookup { Id = 200000000000000001, Category = LookupCategoryEnum.Gender, EnumId = LookupEnum.Male, Name = "Male", Value = 1 },
                new Lookup { Id = 200000000000000002, Category = LookupCategoryEnum.Gender, EnumId = LookupEnum.Female, Name = "Female", Value = 2 },
                                                                   1,
                // ActivityLevel (CategoryId = 100000000000000002) 1,
                new Lookup { Id = 200000000000000003, Category = LookupCategoryEnum.ActivityLevel, EnumId = LookupEnum.Rookie, Name = "Rookie", Value = 1.2 },
                new Lookup { Id = 200000000000000004, Category = LookupCategoryEnum.ActivityLevel, EnumId = LookupEnum.Beginner, Name = "Beginner", Value = 1.375 },
                new Lookup { Id = 200000000000000005, Category = LookupCategoryEnum.ActivityLevel, EnumId = LookupEnum.Intermediate, Name = "Intermediate", Value = 1.55 },
                new Lookup { Id = 200000000000000006, Category = LookupCategoryEnum.ActivityLevel, EnumId = LookupEnum.Advance, Name = "Advance", Value = 1.725 },
                new Lookup { Id = 200000000000000007, Category = LookupCategoryEnum.ActivityLevel, EnumId = LookupEnum.TrueBeast, Name = "TrueBeast", Value = 1.9 },
                                                                   1,
                // Goal (CategoryId = 100000000000000003)          1,
                new Lookup { Id = 200000000000000008, Category = LookupCategoryEnum.Goal, EnumId = LookupEnum.LoseWeight, Name = "Lose Weight", Value = -500 },
                new Lookup { Id = 200000000000000009, Category = LookupCategoryEnum.Goal, EnumId = LookupEnum.GainWeight, Name = "Gain Weight", Value = 300 },
                new Lookup { Id = 200000000000000010, Category = LookupCategoryEnum.Goal, EnumId = LookupEnum.GainMoreFlexible, Name = "Gain More Flexible", Value = 150 },
                new Lookup { Id = 200000000000000011, Category = LookupCategoryEnum.Goal, EnumId = LookupEnum.GetFitter, Name = "Get Fitter/Learn the Basic", Value = 0 },
                                                                   1,
                // Status (CategoryId = 100000000000000004)        1,
                new Lookup { Id = 200000000000000012, Category = LookupCategoryEnum.Status, EnumId = LookupEnum.Weak, Name = "Weak", Value = 0 },
                new Lookup { Id = 200000000000000013, Category = LookupCategoryEnum.Status, EnumId = LookupEnum.Normal, Name = "Normal", Value = 0 },
                new Lookup { Id = 200000000000000014, Category = LookupCategoryEnum.Status, EnumId = LookupEnum.Hard, Name = "Hard", Value = 0 }
            );
        }
    }
}
