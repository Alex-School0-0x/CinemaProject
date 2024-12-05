using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Theater : IModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

    }
}
