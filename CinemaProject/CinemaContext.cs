﻿using CinemaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject
{
    public class CinemaContext(DbContextOptions<CinemaContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Postalcode> Postalcodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(d => d.CreateDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Showtime)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.ShowtimeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Postalcode>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

                
                
        }
    }
}