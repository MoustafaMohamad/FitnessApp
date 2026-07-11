using MediatR;
using ProgressTrackingService.Features.Progress.Commands;
using ProgressTrackingService.Features.Progress.Dtos;
using ProgressTrackingService.Features.Progress.Queries;

namespace ProgressTrackingService.Features.Progress.Endpoints;

public static class ProgressEndpoints
{
    public static IEndpointRouteBuilder MapProgressEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/v1/progress").WithTags("Progress").RequireAuthorization();

        group.MapGet("/", (string? period, DateTime? startDate, DateTime? endDate, HttpContext context, ISender sender, CancellationToken token) =>
            sender.Send(new GetProgressQuery(GetUserId(context), period, startDate, endDate), token));
        group.MapGet("/{userId:long}", (long userId, string? period, DateTime? startDate, DateTime? endDate, ISender sender, CancellationToken token) =>
            sender.Send(new GetProgressQuery(userId, period, startDate, endDate), token));
        group.MapPost("/weight", (AddWeightRequestDto request, ISender sender, CancellationToken token) => sender.Send(new AddWeightCommand(request), token));
        group.MapGet("/weight-history/{userId:long}", (long userId, ISender sender, CancellationToken token) => sender.Send(new GetWeightHistoryQuery(userId), token));
        group.MapGet("/achievements", (HttpContext context, ISender sender, CancellationToken token) => sender.Send(new GetAchievementsQuery(GetUserId(context)), token));
        group.MapGet("/stats/{userId:long}", (long userId, ISender sender, CancellationToken token) => sender.Send(new GetUserStatisticsQuery(userId), token));

        return endpoints;
    }

    private static long GetUserId(HttpContext context) => long.Parse(context.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
}
