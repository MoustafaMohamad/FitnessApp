
using Workout_Exercise_Catalog.Entities;

namespace Workout_Exercise_Catalog.Entities;

    public class WorkoutPlan : BaseEntity
{
        //public int Id { get; set; }

        public string ExternalPlanId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Goal { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string Difficulty { get; set; } = null!;

        public ICollection<Workout> Workouts { get; set; } = null;
    }

