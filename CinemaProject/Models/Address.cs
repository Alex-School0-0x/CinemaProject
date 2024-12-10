using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Address : IModel
    {
        public int Id { get; set; }
        public required string Street1 { get; set; }
        public string Street2 { get; set; } = null!;
        public string ApartmentNumber { get; set; } = null!;
        public required Postalcode Postalcode { get; set; }

    }
}
