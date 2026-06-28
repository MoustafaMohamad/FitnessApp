using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Workout_Exercise_Catalog.Data.Contexts;
using System.Linq.Expressions;
using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Entities;

namespace Workout_Exercise_Catalog.Common.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CancellationToken cancellationToken;
        private readonly Context _context;
        public Repository(Context context, CancellationTokenAccessor cancellationTokenAccessor)
        {
            _context = context;
            cancellationToken = cancellationTokenAccessor.Token;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
        }

        //public IQueryable<T> Get(Expression<Predicate<T> > expression)
        //{
        //    return GetAll
        //}

        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {

            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id, cancellationToken);
        }

        public void UpdateIncluded(T entity, params string[] updatedProperties)
        {
            if (!_context.Set<T>().Any(x => x.Id == entity.Id))
                return;

            T local = _context.Set<T>().Local.FirstOrDefault(x => x.Id == entity.Id);

            EntityEntry entityEntry;

            if (local is null)
            {
                entityEntry = _context.Entry(entity);
            }
            else
            {
                entityEntry = _context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.Id == entity.Id);
            }

            foreach (var property in entityEntry.Properties)
            {
                if (updatedProperties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }
            }
        }

        public async void Delete(T entity)
        {
            entity.IsDeleted = true;
            UpdateIncluded(entity, nameof(entity.IsDeleted));
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
        }


    }
}
