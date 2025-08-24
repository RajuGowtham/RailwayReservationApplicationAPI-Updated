using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(User user);
    }
}
