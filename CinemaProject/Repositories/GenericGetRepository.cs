using CinemaProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Repositories
{
    public class GenericGetRepository<T> : IGetRepository<T> where T : class, IModel
    {
        private readonly CinemaContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericGetRepository(CinemaContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new Exception($"{typeof(T).Name} with ID {id} not found.");
            return entity;
        }

        public async Task<bool> EntityExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }
    }
}
