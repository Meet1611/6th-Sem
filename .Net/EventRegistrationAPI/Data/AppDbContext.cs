using EventRegistrationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventRegistrationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<EventRegistration> EventRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRegistration>()
               .HasIndex(u => u.RegistrationId)
               .IsUnique();
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRegistration>().HasData(
                new EventRegistration
                {
                    RegistrationId = 1,
                    ParticipantName = "Rahul Mehta",
                    Email = "rahul@gmail.com",
                    EventName = "Frolic",
                    Age = 24,
                    RegistrationDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
