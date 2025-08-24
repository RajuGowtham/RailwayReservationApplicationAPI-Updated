using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _repository.GetAllBookingsAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _repository.GetBookingByIdAsync(id);
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            booking.BookingDate = DateTime.Now; // set booking date
            return await _repository.AddBookingAsync(booking);
        }

        public async Task UpdateBookingAsync(int id, Booking booking)
        {
            var exists = await _repository.BookingExistsAsync(id);
            if (!exists) throw new KeyNotFoundException("Booking not found.");
            await _repository.UpdateBookingAsync(booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            var exists = await _repository.BookingExistsAsync(id);
            if (!exists) throw new KeyNotFoundException("Booking not found.");
            await _repository.DeleteBookingAsync(id);
        }
    }
}
