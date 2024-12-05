using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Movie : IModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? PosterUrl { get; set; }
        public int DurationInMinutes { get; set; }
        public int Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<Genre>? Genres { get; set; }
    }
}
