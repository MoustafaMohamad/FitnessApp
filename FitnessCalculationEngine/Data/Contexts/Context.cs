using FitnessCalculationEngine.Common.Services;
using FitnessCalculationEngine.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCalculationEngine.Data.Contexts
{
    public class Context : DbContext
    {
        private readonly CurrentUserService _currentUserService;

        public Context(DbContextOptions<Context> options, CurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseInformation>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedById = _currentUserService.UserId;
                        entry.Entity.IsActive = true; 
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedById = _currentUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
      
        public DbSet<UserFitnessStats> UserFitnessStats { get; set; }
        public DbSet<CalculatedMetrics> CalculatedMetrics { get; set; }
        public DbSet<FitnessPlanConfig> FitnessPlanConfigs { get; set; }
        public DbSet<UserAssignedPlan> UserAssignedPlans { get; set; }
        public DbSet<UserPlanHistory> UserPlanHistories { get; set; }
        public DbSet<Lookup> Lookups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
