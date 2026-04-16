using Microsoft.AspNetCore.Mvc;
using flappyBirdServeur.Models;

namespace flappyBirdServeur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        [HttpGet("GetBestScores")]
        public ActionResult<IEnumerable<Scores>> GetBestScores()
        {
            return Ok();
        }

        [HttpGet("GetMyScores")]
        public ActionResult<IEnumerable<Scores>> GetMyScores()
        {
            return Ok();
        }

        [HttpPut("ChangeScoreVisibility/{id}")]
        public IActionResult ChangeScoreVisibility(int id)
        {
            return NoContent();
        }

        [HttpPost("PostScore")]
        public ActionResult<Scores> PostScore(Scores score)
        {
            return Ok(score);
        }
    }
}