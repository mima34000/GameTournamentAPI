using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Represents the Tournaments table in the database
        public DbSet<Tournament> Tournaments { get; set; }
    }
}