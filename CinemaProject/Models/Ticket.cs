﻿using CinemaProject.Interfaces;

namespace CinemaProject.Models
{
    public class Ticket : IModel
    {
        public int Id { get; set; }
        public required User User { get; set; }
        public int UserId { get; set; }
        public required Showtime Showtime { get; set; }
        public int ShowtimeId { get; set; }
        public required Seat Seat { get; set; }
        public int SeatId { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }
}
