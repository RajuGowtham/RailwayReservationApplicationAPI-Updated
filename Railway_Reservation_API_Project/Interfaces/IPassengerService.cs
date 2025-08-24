using NuGet.Protocol.Core.Types;
using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Interfaces
{
    public interface IPassengerService
    {
        Task<IEnumerable<Passenger>> GetAllPassengersAsync();
        Task<Passenger> GetPassengerByIdAsync(int id);
        Task<Passenger> CreatePassengerAsync(Passenger passenger);
        Task<Passenger> UpdatePassengerAsync(Passenger passenger);
        Task<bool> DeletePassengerAsync(int id);

        // additional operations

        Task<IEnumerable<Passenger>> SearchPassengersAsync(string name);
        Task<IEnumerable<Passenger>> FilterPassengersByAgeAsync(int minAge, int maxAge);
        Task<IEnumerable<Passenger>> SortPassengersByNameAsync(bool ascending);


    }
}
