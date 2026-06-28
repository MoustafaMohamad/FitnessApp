namespace Workout_Exercise_Catalog.Entities
{
//    public enum category
//    {
//         FullBody ,
//     Chest ,
//    Arms ,
//     Shoulders ,
//     Back ,
//     Legs ,
//     Stomach ,
//}
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Workout> Workouts { get; set; } = null;

    }

}
