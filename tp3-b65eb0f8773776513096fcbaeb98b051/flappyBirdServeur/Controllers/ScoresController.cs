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
        public async Task<ActionResult<IEnumerable<DisplayDTO>>> GetBestScores()
        {
            return await _scoreService.GetBestScores();
        }

        [HttpGet("GetMyScores")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Scores>>> GetMyScores()
        {
            Users? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var score = await _scoreService.GetMyScores(user.Id);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(score);
        }

        [HttpPut("ChangeScoreVisibility/{id}")]
        public async Task<IActionResult> ChangeScoreVisibility(int id)
        {
         
            await _scoreService.ChangeScoreVisibility(id);
            return Ok();
        }

        [HttpPost("PostScore")]

        public async Task<ActionResult<Scores>> PostScore(ScoreDTO scoreDTO)
        {
            Users? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (user == null) return Unauthorized();

            Scores score = new Scores
            {
                Id = 0,
                Points = scoreDTO.Points,
                Chrono = scoreDTO.Chrono,
                Visibilité = true,
                Date = DateTime.Now.ToString(),         
                UserId = user.Id
            };

             await _scoreService.PostScore(scoreDTO, user);

            return Ok(score);
        }
    }
}