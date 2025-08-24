using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Services
{
    public class TrainService : ITrainService
    {
        private readonly ITrainRepository _repository;

        public TrainService(ITrainRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Train>> GetAllTrainsAsync()
        {
            return await _repository.GetAllTrainsAsync();
        }

        public async Task<Train> GetTrainByIdAsync(int id)
        {
            return await _repository.GetTrainByIdAsync(id);
        }

        public async Task<Train> AddTrainAsync(Train train)
        {
            return await _repository.AddTrainAsync(train);
        }

        public async Task UpdateTrainAsync(int id, Train train)
        {
            var exists = await _repository.TrainExistsAsync(id);
            if (!exists) throw new KeyNotFoundException("Train not found.");
            await _repository.UpdateTrainAsync(train);
        }

        public async Task DeleteTrainAsync(int id)
        {
            var exists = await _repository.TrainExistsAsync(id);
            if (!exists) throw new KeyNotFoundException("Train not found.");
            await _repository.DeleteTrainAsync(id);
        }
    }
}
