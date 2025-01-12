using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Address : IModel
    {
        public int Id { get; set; }
        public required string Street { get; set; }
        public string? ApartmentNumber { get; set; }
        public required Postalcode Postalcode { get; set; }

    }
}
