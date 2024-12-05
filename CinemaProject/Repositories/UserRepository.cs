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

        public CinemaContext DbContext => dbContext;

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public bool EntityExists(int id)
        {
            return dbContext.Users.Any(u => u.Id == id);
        }

        public List<User> GetAll() => DbContext.Users.ToList();

        public User? GetById(int id)
        {
            return DbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Post(User entity)
        {
            throw new NotImplementedException();
        }

        public void Put(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
