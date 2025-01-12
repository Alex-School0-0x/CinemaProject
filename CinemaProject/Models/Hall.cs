using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Hall : IModel
    {
        public int Id {  get; set; }
        public required string Name { get; set; }
        public List<Seat> Seats { get; set; } = null!;
    }
}
