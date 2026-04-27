namespace GameTournamentAPI.Models
{
    public class Tournament
    {
        // Unique identifier for the tournament
        public int Id { get; set; }

        // Name of the tournament
        public string Title { get; set; } = string.Empty;

        // Description of the tournament
        public string Description { get; set; } = string.Empty;

        // Maximum number of players allowed
        public int MaxPlayers { get; set; }

        // Date when the tournament takes place
        public DateTime Date { get; set; }
    }
}