using CinemaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject
{
    public class CinemaContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
