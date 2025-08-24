using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Railway_Reservation_API_Project.DTOs;
using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;
using System;

namespace Railway_Reservation_API_Project.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly RailwayReservationContext _context;

        public PassengerRepository(RailwayReservationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Passenger>> GetAllAsync()
        {
            return await _context.Passengers.ToListAsync();
        }

        public async Task<Passenger> GetByIdAsync(int id)
        {
            return await _context.Passengers.FindAsync(id);
        }

        public async Task<Passenger> AddAsync(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();
            return passenger;
        }

        public async Task<Passenger> UpdateAsync(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            await _context.SaveChangesAsync();
            return passenger;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null) return false;

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();
            return true;
        }

        // --- Search by Name ---
        //public async Task<SearchResult<Passenger>> SearchAsync(string name)
        public async Task<IEnumerable<Passenger>> SearchAsync(string name)
        {
            return await _context.Passengers
                .Where(p => p.FullName.Contains(name))
                .ToListAsync();
        }

        // --- Filter by Age Range ---
        public async Task<IEnumerable<Passenger>> FilterByAgeAsync(int minAge, int maxAge)
        {
            return await _context.Passengers
                .Where(p => p.Age >= minAge && p.Age <= maxAge)
                .ToListAsync();
        }

        // --- Sort by Name ---
        public async Task<IEnumerable<Passenger>> SortByNameAsync(bool ascending = true)
        {
            return ascending
                ? await _context.Passengers.OrderBy(p => p.FullName).ToListAsync()
                : await _context.Passengers.OrderByDescending(p => p.FullName).ToListAsync();
        }

    }
}
