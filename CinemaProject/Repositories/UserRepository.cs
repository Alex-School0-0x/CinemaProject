using System.Data.Common;
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
            throw new NotImplementedException();
        }

        public List<User> GetAll() => DbContext.Users.ToList();

        public User GetById(int id)
        {
            throw new NotImplementedException();
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
