namespace CinemaProject.Models
{
    public class Genre : IModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

    }
}
