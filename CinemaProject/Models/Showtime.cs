using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Showtime : IModel
    {
        public int Id { get; set; }
        public required Movie Movie { get; set; }
        public required Theater Theater { get; set; }
        public required Hall Hall { get; set; }
        public List<Ticket> Tickets { get; set; } = null!;
        public DateTime ShowStart { get; set; }
    }
}
