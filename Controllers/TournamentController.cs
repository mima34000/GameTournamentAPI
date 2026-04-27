using GameTournamentAPI.Dtos;
using GameTournamentAPI.Models;
using GameTournamentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentAPI.Controllers
{
    [ApiController]
    [Route("api/tournaments")]
    public class TournamentController : ControllerBase
    {
        private readonly TournamentService _service;

        public TournamentController(TournamentService service)
        {
            _service = service;
        }

        // GET /api/tournaments or GET /api/tournaments?search=name
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search = null)
        {
            var tournaments = await _service.GetAllAsync(search);

            var response = tournaments.Select(t => new TournamentResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                MaxPlayers = t.MaxPlayers,
                Date = t.Date
            });

            return Ok(response);
        }

        // GET /api/tournaments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tournament = await _service.GetByIdAsync(id);
            if (tournament == null) return NotFound();

            var response = new TournamentResponseDto
            {
                Id = tournament.Id,
                Title = tournament.Title,
                MaxPlayers = tournament.MaxPlayers,
                Date = tournament.Date
            };

            return Ok(response);
        }

        // POST /api/tournaments
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TournamentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var tournament = new Tournament
            {
                Title = dto.Title,
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            var created = await _service.CreateAsync(tournament);

            var response = new TournamentResponseDto
            {
                Id = created.Id,
                Title = created.Title,
                MaxPlayers = created.MaxPlayers,
                Date = created.Date
            };

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
        }

        // PUT /api/tournaments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TournamentUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var tournament = new Tournament
            {
                Title = dto.Title,
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            var updated = await _service.UpdateAsync(id, tournament);
            if (updated == null) return NotFound();

            var response = new TournamentResponseDto
            {
                Id = updated.Id,
                Title = updated.Title,
                MaxPlayers = updated.MaxPlayers,
                Date = updated.Date
            };

            return Ok(response);
        }

        // DELETE /api/tournaments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}