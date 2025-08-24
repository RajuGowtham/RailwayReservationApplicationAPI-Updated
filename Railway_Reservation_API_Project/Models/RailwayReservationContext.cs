using Microsoft.EntityFrameworkCore;

namespace Railway_Reservation_API_Project.Models
{
    public class RailwayReservationContext : DbContext
    {
        public RailwayReservationContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Passenger>().ToTable("Passengers");
            modelBuilder.Entity<Train>().ToTable("Trains");
            modelBuilder.Entity<Booking>().ToTable("Bookings");

            // Fluent API configurations
            // User <-> Passenger (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Passenger)
                .WithOne(p => p.User)
                .HasForeignKey<Passenger>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Passenger <-> Booking (One-to-Many)
            modelBuilder.Entity<Passenger>()
                .HasMany(p => p.Bookings)
                .WithOne(b => b.Passenger)
                .HasForeignKey(b => b.PassengerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Train <-> Booking (One-to-Many)
            modelBuilder.Entity<Train>()
                .HasMany(t => t.Bookings)
                .WithOne(b => b.Train)
                .HasForeignKey(b => b.TrainId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingDate)
                .HasDefaultValueSql("GETDATE()"); // Set default value to current date and time


            base.OnModelCreating(modelBuilder);
        }
    }
}
