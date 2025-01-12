using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Theater : IModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Hall> Halls { get; set; } = null!;
        public required Address Address { get; set; }

    }
}
