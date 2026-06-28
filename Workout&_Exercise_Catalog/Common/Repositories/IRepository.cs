using System.Linq.Expressions;
using Workout_Exercise_Catalog.Entities;

namespace Workout_Exercise_Catalog.Common.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        void UpdateIncluded(T entity, params string[] updatedProperties);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Delete(T entity);

    }
}
