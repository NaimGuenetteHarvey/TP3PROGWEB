using flappyBirdServeur.Data;
using flappyBirdServeur.DTOs;
using flappyBirdServeur.Models;
using Microsoft.EntityFrameworkCore;

namespace flappyBirdServeur.Services
{
    public class ScoreService
    {
        private readonly flappyBirdServeurContext _context;

        public ScoreService(flappyBirdServeurContext context)
        {
            _context = context;
        }

        public async Task<List<DisplayDTO>> GetBestScores()
        {
            return await _context.Scores
                .Where(s => s.Visibilité)
                .OrderByDescending(s => s.Points)
                .Take(10)
                .Select(s => new DisplayDTO
                {
                    Id = s.Id,
                    Pseudo = s.User.UserName,
                    Points = s.Points,
                    Chrono = s.Chrono,
                    Visibilité = s.Visibilité,
                    Date = s.Date              
                })
        .ToListAsync();
        }

        public async Task<List<Scores>> GetMyScores(string userId)
        {
            return await _context.Scores
                .Where(s => s.UserId == userId)         
                .ToListAsync();
        }

        public async Task<Scores> PostScore(ScoreDTO scoreDTO, Users users)
        {
            var score = new Scores
            {
                Points = scoreDTO.Points,
                Chrono = scoreDTO.Chrono,
                Date = DateTime.Now.ToString("dd/MM/yyyy"),
                UserId = users.Id,
                Visibilité = true
            };
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
            return score;
        }

        public async Task ChangeScoreVisibility(int id)
        {
            Scores score = await _context.Scores.FirstOrDefaultAsync(s => s.Id == id);

            if (score != null)
            {
                score.Visibilité = !score.Visibilité;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> Save()
        { 
         return await _context.SaveChangesAsync();
        }
    
}
}
