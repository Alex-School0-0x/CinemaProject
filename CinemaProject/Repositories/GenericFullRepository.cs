using CinemaProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Repositories
{
    public class GenericFullRepository<T> : GenericGetRepository<T>, IFullRepository<T> where T : class, IModel
    {
        private readonly CinemaContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericFullRepository(CinemaContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }


        public async Task<T> PostAsync(T entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<T> PutAsync(T entity)
        {
            var existingEntity = await _dbSet.FindAsync(entity.Id);
            if (existingEntity == null)
                throw new Exception($"{typeof(T).Name} with ID {entity.Id} not found.");

            var entityEntry = _dbContext.Entry(existingEntity);
            entityEntry.CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new Exception($"{typeof(T).Name} with ID {id} not found.");

            var entityEntry = _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}
