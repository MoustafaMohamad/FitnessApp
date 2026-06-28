
using Mapster;
using Workout_Exercise_Catalog.Entities;
using Workout_Exercise_Catalog.Features.Workouts.Dtos;

namespace Workout_Exercise_Catalog.Common.Profiles
{
    public class Profile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Workout, WorkoutListItemDto>()
                .Map(dest => dest.PlanName, src => src.WorkoutPlan.Name)
                .Map(dest => dest.Category, src => src.Category.Name);
            config.NewConfig<WorkoutExercise, WorkoutExerciseDto>()
                .Map(dest => dest.Name, src => src.Exercise.Name)
                .Map(dest => dest.TargetMuscles, src => src.Exercise.TargetMuscles)
                .Map(dest => dest.Equipment, src => src.Exercise.EquipmentNeeded)
                .Map(dest => dest.Description, src => src.Exercise.Description)
                .Map(dest => dest.VideoUrl, src => src.Exercise.VideoUrl);
        }
    }
}
