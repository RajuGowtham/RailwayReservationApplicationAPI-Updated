using Microsoft.EntityFrameworkCore;
using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly RailwayReservationContext _context;

        public UserRepository(RailwayReservationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() // GET
        {
            return await _context.Users.ToListAsync();  
        }

        public async Task<User?> GetByIdAsync(int id) // GET by ID
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddAsync(User user) // POST
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user) // PUT
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id) // DELETE
        {
            var user = await _context.Users.FindAsync(id);  // checking whether user exists or not
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
