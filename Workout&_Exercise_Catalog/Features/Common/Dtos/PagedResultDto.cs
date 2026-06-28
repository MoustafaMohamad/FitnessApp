namespace Workout_Exercise_Catalog.Features.Common.Dtos
{
    public record PagedResultDto<T>(
        IReadOnlyCollection<T> Items,
        int Page,
        int PageSize,
        int TotalCount,
        int TotalPages);
}
