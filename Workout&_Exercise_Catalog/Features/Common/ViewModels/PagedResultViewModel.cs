namespace Workout_Exercise_Catalog.Features.Common.ViewModels
{
    public record PagedResultViewModel<T>(
        IReadOnlyCollection<T> Items,
        int Page,
        int PageSize,
        int TotalCount,
        int TotalPages);
}
