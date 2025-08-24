using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Interfaces
{
    public interface ITrainRepository
    {
        Task<IEnumerable<Train>> GetAllTrainsAsync();
        Task<Train> GetTrainByIdAsync(int id);
        Task<Train> AddTrainAsync(Train train);
        Task UpdateTrainAsync(Train train);
        Task DeleteTrainAsync(int id);
        Task<bool> TrainExistsAsync(int id);
    }
}
