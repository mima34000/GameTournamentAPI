using GameTournamentAPI.Data;
using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentAPI.Services
{
    public class TournamentService
    {
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        // Get all tournaments, with optional search by title
        public async Task<List<Tournament>> GetAllAsync(string? search = null)
        {
            var query = _context.Tournaments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(t => t.Title.Contains(search));
            }

            return await query.ToListAsync();
        }

        // Get a single tournament by id
        public async Task<Tournament?> GetByIdAsync(int id)
        {
            return await _context.Tournaments.FindAsync(id);
        }

        // Create a new tournament
        public async Task<Tournament> CreateAsync(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        // Update an existing tournament
        public async Task<Tournament?> UpdateAsync(int id, Tournament tournament)
        {
            var existing = await _context.Tournaments.FindAsync(id);
            if (existing == null) return null;

            existing.Title = tournament.Title;
            existing.Description = tournament.Description;
            existing.MaxPlayers = tournament.MaxPlayers;
            existing.Date = tournament.Date;

            await _context.SaveChangesAsync();
            return existing;
        }

        // Delete a tournament by id
        public async Task<bool> DeleteAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null) return false;

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}