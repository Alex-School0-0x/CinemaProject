﻿using System.Data.Common;
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

        public async Task<bool> DeleteAsync(User entity)
        {
            var entityEntry = dbContext.Users.Remove(entity);
            if (entityEntry == null || entityEntry.State != EntityState.Deleted) return false;            
            int t = await dbContext.SaveChangesAsync();
            return t > 0;
        }

        public async Task<bool> EntityExistsAsync(int id) => await dbContext.Users.AnyAsync(e => e.Id == id);

        public async Task<List<User>> GetAllAsync() => await dbContext.Users.ToListAsync();

        public async Task<User> GetByIdAsync(int id) => await dbContext.Users.FirstAsync(e => e.Id == id);

        public async Task<bool> PostAsync(User entity)
        {
            await dbContext.Users.AddAsync(entity);
            int t = await dbContext.SaveChangesAsync();
            return t > 0;
        }

        public async Task<bool> PutAsync(User entity)
        {
            var oldEntity = await dbContext.Users.FirstAsync(e => e.Id == entity.Id);
            if (oldEntity == null) return false;
            foreach (var p in oldEntity.GetType().GetProperties())
            {
                if (p.Name == "Id") continue;
                p.SetValue(oldEntity, p.GetValue(entity));
            }
            int t = await dbContext.SaveChangesAsync();
            return t > 0;
        }
    }
}
