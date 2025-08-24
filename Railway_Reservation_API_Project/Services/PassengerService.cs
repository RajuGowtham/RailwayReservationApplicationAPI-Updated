using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _repository;

        public PassengerService(IPassengerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Passenger>> GetAllPassengersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Passenger> GetPassengerByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Passenger> CreatePassengerAsync(Passenger passenger)
        {
            return await _repository.AddAsync(passenger);
        }

        public async Task<Passenger> UpdatePassengerAsync(Passenger passenger)
        {
            return await _repository.UpdateAsync(passenger);
        }

        public async Task<bool> DeletePassengerAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }


        // additional operations
        public Task<IEnumerable<Passenger>> SearchPassengersAsync(string name) => _repository.SearchAsync(name);
        public Task<IEnumerable<Passenger>> FilterPassengersByAgeAsync(int minAge, int maxAge) => _repository.FilterByAgeAsync(minAge, maxAge);
        public Task<IEnumerable<Passenger>> SortPassengersByNameAsync(bool ascending) => _repository.SortByNameAsync(ascending);



    }
}
