using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.Dtos
{
    public class TournamentResponseDto
    {
        // Unique identifier
        [Required]
        public int Id { get; set; }

        // Name of the tournament
        [Required]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;

        // Maximum number of players
        [Required]
        public int MaxPlayers { get; set; }

        // Date of the tournament
        [Required]
        [FutureDate]
        public DateTime Date { get; set; }
    }
}