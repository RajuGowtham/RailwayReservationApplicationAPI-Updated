using Microsoft.EntityFrameworkCore;
using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;
using System;

namespace Railway_Reservation_API_Project.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly RailwayReservationContext _context;

        public TrainRepository(RailwayReservationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Train>> GetAllTrainsAsync()
        {
            return await _context.Trains
                                 .Include(t => t.Bookings)
                                 .ToListAsync();
        }

        public async Task<Train> GetTrainByIdAsync(int id)
        {
            return await _context.Trains
                                 .Include(t => t.Bookings)
                                 .FirstOrDefaultAsync(t => t.TrainId == id);
        }

        public async Task<Train> AddTrainAsync(Train train)
        {
            _context.Trains.Add(train);
            await _context.SaveChangesAsync();
            return train;
        }

        public async Task UpdateTrainAsync(Train train)
        {
            _context.Entry(train).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainAsync(int id)
        {
            var train = await _context.Trains.FindAsync(id);
            if (train != null)
            {
                _context.Trains.Remove(train);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> TrainExistsAsync(int id)
        {
            return await _context.Trains.AnyAsync(t => t.TrainId == id);
        }
    }
}
