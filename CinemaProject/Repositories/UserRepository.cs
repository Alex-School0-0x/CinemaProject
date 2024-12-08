using System.Data.Common;
using CinemaProject.Interfaces;
using CinemaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Repositories
{
    public class UserRepository : IFullRepository<User>
    {
        private readonly CinemaContext dbContext;

        public UserRepository(CinemaContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> DeleteAsync(User entity)
        {
            var entityEntry = dbContext.Users.Remove(entity);
            if (entityEntry == null || entityEntry.State != EntityState.Deleted) 
                throw new Exception("Entity was not deleted/Entity might not exist");            
            int t = await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> EntityExistsAsync(int id) => await dbContext.Users.AnyAsync(e => e.Id == id);

        public async Task<List<User>> GetAllAsync() => await dbContext.Users.ToListAsync();

        public async Task<User> GetByIdAsync(int id) => await dbContext.Users.FirstAsync(e => e.Id == id);

        public async Task<User> PostAsync(User entity)
        {
            await dbContext.Users.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return await dbContext.Users.LastAsync();
        }

        public async Task<User> PutAsync(User entity)
        {
            var oldEntity = await dbContext.Users.FirstAsync(e => e.Id == entity.Id);
            if (oldEntity == null) throw new Exception("Entity not found");
            foreach (var p in oldEntity.GetType().GetProperties())
            {
                if (p.Name == "Id") continue;
                p.SetValue(oldEntity, p.GetValue(entity));
            }
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
