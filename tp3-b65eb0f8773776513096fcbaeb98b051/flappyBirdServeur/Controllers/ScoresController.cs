using flappyBirdServeur.Data;
using flappyBirdServeur.DTOs;
using flappyBirdServeur.Models;
using flappyBirdServeur.Services;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace flappyBirdServeur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase

    {
        private readonly ScoreService _scoreService;
        private readonly UserManager<Users> _userManager;
        public ScoresController(ScoreService scoreService, UserManager<Users> userManager)
        {
            _scoreService = scoreService;
            _userManager = userManager;
        }
        [HttpGet("GetBestScores")]
        public async Task<ActionResult<IEnumerable<Scores>>> GetBestScoresAsync()
        {
            return await _scoreService.GetBestScoresAsync();
        }

        [HttpGet("GetMyScores")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Scores>>> GetMyScoresAsync()
        {
            Users? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (user == null)
            {
                return Unauthorized();
            }

            return await _scoreService.GetMyScoresAsync(user.Id);
        }

        [HttpPut("ChangeScoreVisibility/{id}")]
        public async Task<IActionResult> ChangeScoreVisibilityAsync(int id)
        {
            Users? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (user == null)
            {
                return Unauthorized();
            }

            Scores? score = await _scoreService.GetScoreByIdAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            if (score.UserId != user.Id)
            {
                return Forbid();
            }

            bool success = await _scoreService.ChangeScoreVisibilityAsync(score);

            if (!success)
            {
                return StatusCode(500, new { Message = "Veuillez réessayer plus tard." });
            }

            return NoContent();
        }

        [HttpPost("PostScore")]
        [Authorize]
        public async Task<ActionResult<Scores>> PostScoreAsync(DisplayDTO displayDTO)
        {
            Users? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (user == null) return Unauthorized();

            Scores score = new Scores
            {
                Points = displayDTO.Points,
                Chrono = displayDTO.Chrono,
                UserId = user.Id
            };

            Scores newScore = await _scoreService.PostScoreAsync(score);

            return Ok(newScore);
        }
    }
}