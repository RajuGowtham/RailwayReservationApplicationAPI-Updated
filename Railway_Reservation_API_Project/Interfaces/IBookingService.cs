using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> AddBookingAsync(Booking booking);
        Task UpdateBookingAsync(int id, Booking booking);
        Task DeleteBookingAsync(int id);
    }
}
