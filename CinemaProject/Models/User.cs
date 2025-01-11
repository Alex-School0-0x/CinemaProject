using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class User : IModel
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required Postalcode Postalcode { get; set; }
        public List<Ticket>? Tickets { get; set; }
        public DateOnly CreateDate { get; set; }
    }
}
