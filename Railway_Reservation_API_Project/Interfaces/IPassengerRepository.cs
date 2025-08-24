using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Railway_Reservation_API_Project.DTOs;
using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Interfaces
{
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> GetAllAsync();
        Task<Passenger> GetByIdAsync(int id);
        Task<Passenger> AddAsync(Passenger passenger);
        Task<Passenger> UpdateAsync(Passenger passenger);
        Task<bool> DeleteAsync(int id);


        // New methods for search, sort, filter
        Task<IEnumerable<Passenger>> SearchAsync(string name);
        Task<IEnumerable<Passenger>> FilterByAgeAsync(int minAge, int maxAge);
        Task<IEnumerable<Passenger>> SortByNameAsync(bool ascending = true);

        

    }
}
