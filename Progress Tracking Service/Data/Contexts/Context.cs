using Microsoft.EntityFrameworkCore;
using Progress_Tracking_Service.Entities;
using ProgressTrackingService.Common.Services;

namespace ProgressTrackingService.Data.Contexts
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
      
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
        public DbSet<Streak> Streaks { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<UserStatistics> UserStatisticss { get; set; }
        public DbSet<WeightHistory> WeightHistory { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        public DbSet<WorkoutLogExercise> WorkoutLogExercises { get; set; }

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
