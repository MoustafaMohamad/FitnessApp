// using MediatR;
// using ProgressTrackingService.Features.WorkoutLogs.Commands;
// using ProgressTrackingService.Features.WorkoutLogs.Dtos;

// namespace ProgressTrackingService.Features.WorkoutLogs.Endpoints;

// public static class WorkoutLogEndpoints
// {
//     public static IEndpointRouteBuilder MapWorkoutLogEndpoints(this IEndpointRouteBuilder endpoints)
//     {
//         var group = endpoints.MapGroup("/api/v1/progress").WithTags("Progress").RequireAuthorization();

//         group.MapPost("/", async (AddWorkoutLogRequestDto request, ISender sender, CancellationToken cancellationToken) =>
//         {
//             var result = await sender.Send(new AddWorkoutLogCommand(request), cancellationToken);
//             return Results.Created($"/api/workout-logs/{result.Data.Id}", result);
//         }).WithName("AddWorkoutLog");

//         return endpoints;
//     }
// }
