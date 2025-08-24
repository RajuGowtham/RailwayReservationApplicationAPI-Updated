using Microsoft.EntityFrameworkCore;
using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;
using System;

namespace Railway_Reservation_API_Project.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RailwayReservationContext _context;

        public BookingRepository(RailwayReservationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                                 .Include(b => b.Passenger)
                                 .Include(b => b.Train)
                                 .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings.Include(b => b.Passenger).Include(b => b.Train).FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> BookingExistsAsync(int id)
        {
            return await _context.Bookings.AnyAsync(b => b.BookingId == id);
        }
    }
}
