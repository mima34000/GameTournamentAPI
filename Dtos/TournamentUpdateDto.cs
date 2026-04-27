using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.Dtos
{
    public class TournamentUpdateDto
    {
        // Title is required and must be at least 3 characters
        [Required]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;

        // Description of the tournament
        public string Description { get; set; } = string.Empty;

        // Maximum number of players
        public int MaxPlayers { get; set; }

        // Date must not be in the past
        [FutureDate]
        public DateTime Date { get; set; }
    }
}