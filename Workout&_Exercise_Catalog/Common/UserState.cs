using Workout_Exercise_Catalog.Entities;

namespace Workout_Exercise_Catalog.Common
{
    public sealed record UserState
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
