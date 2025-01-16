using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    /// <summary>
    /// I need Some forklaring for the properties
    /// </summary>
    public class Address : IModel
    {

        public int Id { get; set; }
        public required string Street { get; set; }
        public string? ApartmentNumber { get; set; }
        public required Postalcode Postalcode { get; set; }

    }
}
