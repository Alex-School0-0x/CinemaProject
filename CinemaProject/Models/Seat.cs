using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Seat : IModel
    {
        public int Id { get; set; }
        public int HallNumber { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public decimal price { get; set; }
    }
}
