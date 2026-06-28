namespace Workout_Exercise_Catalog.Entities
{
    public class BaseEntity
    {
        private static readonly Random random = new Random();

        public long Id { get; set; } =
            ((long)random.Next() << 32) | (uint)random.Next();
        public bool IsDeleted { get; set; } = false;
    }
}
