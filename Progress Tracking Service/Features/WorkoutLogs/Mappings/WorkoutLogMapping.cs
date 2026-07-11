// using Mapster;
// using Progress_Tracking_Service.Entities;
// using ProgressTrackingService.Features.WorkoutLogs.Dtos;

// namespace ProgressTrackingService.Features.WorkoutLogs.Mappings;

// public sealed class WorkoutLogMapping : IRegister
// {
//     public void Register(TypeAdapterConfig config)
//     {
//         config.NewConfig<AddWorkoutLogRequestDto, WorkoutLog>()
//             .Map(destination => destination.DurationInMinutes, source => source.Duration)
//             .Ignore(destination => destination.Id)
//             .Ignore(destination => destination.UserId)
//             .Ignore(destination => destination.Exercises);
//         config.NewConfig<AddWorkoutLogExerciseDto, WorkoutLogExercise>()
//             .Map(destination => destination.SetsCompleted, source => source.Sets)
//             .Map(destination => destination.RepsCompleted, source => source.Reps)
//             .Ignore(destination => destination.Id)
//             .Ignore(destination => destination.WorkoutLogId)
//             .Ignore(destination => destination.WorkoutLog);
//         config.NewConfig<WorkoutLog, WorkoutLogDto>();
//         config.NewConfig<WorkoutLogExercise, WorkoutLogExerciseDto>();
//     }
// }
