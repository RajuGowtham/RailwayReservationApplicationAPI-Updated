using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(); // GET
        Task<User?> GetByIdAsync(int id); // GET by ID
        Task<User> AddAsync(User user); // POST
        Task<User> UpdateAsync(User user); // PUT
        Task<bool> DeleteAsync(int id); // DELETE

    }
}
