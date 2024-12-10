using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Postalcode : IModel
    {
        public int Id {  get; set; }
        public required string Name { get; set; }
    }
}
