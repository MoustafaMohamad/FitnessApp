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
                // Gender
                new Lookup { Id = LookupEnum.Male, CategoryId = LookupCategoryEnum.Gender, Name = "Male", Value = 1 },
                new Lookup { Id = LookupEnum.Female, CategoryId = LookupCategoryEnum.Gender, Name = "Female", Value = 2 },

                // ActivityLevel
                new Lookup { Id = LookupEnum.Rookie, CategoryId = LookupCategoryEnum.ActivityLevel, Name = "Rookie", Value = 1.2 },
                new Lookup { Id = LookupEnum.Beginner, CategoryId = LookupCategoryEnum.ActivityLevel, Name = "Beginner", Value = 1.375 },
                new Lookup { Id = LookupEnum.Intermediate, CategoryId = LookupCategoryEnum.ActivityLevel, Name = "Intermediate", Value = 1.55 },
                new Lookup { Id = LookupEnum.Advance, CategoryId = LookupCategoryEnum.ActivityLevel, Name = "Advance", Value = 1.725 },
                new Lookup { Id = LookupEnum.TrueBeast, CategoryId = LookupCategoryEnum.ActivityLevel, Name = "TrueBeast", Value = 1.9 },

                // Goal
                new Lookup { Id = LookupEnum.LoseWeight, CategoryId = LookupCategoryEnum.Goal, Name = "Lose Weight", Value = -500 },
                new Lookup { Id = LookupEnum.GainWeight, CategoryId = LookupCategoryEnum.Goal, Name = "Gain Weight", Value = 300 },
                new Lookup { Id = LookupEnum.GainMoreFlexible, CategoryId = LookupCategoryEnum.Goal, Name = "Gain More Flexible", Value = 150 },
                new Lookup { Id = LookupEnum.GetFitter, CategoryId = LookupCategoryEnum.Goal, Name = "Get Fitter/Learn the Basic", Value = 0 },

                // Status
                new Lookup { Id = LookupEnum.Weak, CategoryId = LookupCategoryEnum.Status, Name = "Weak", Value = 0 },
                new Lookup { Id = LookupEnum.Normal, CategoryId = LookupCategoryEnum.Status, Name = "Normal", Value = 0 },
                new Lookup { Id = LookupEnum.Hard, CategoryId = LookupCategoryEnum.Status, Name = "Hard", Value = 0 }
            );
        }
    }
}
