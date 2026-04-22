using flappyBirdServeur.Data;
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

        public async Task<List<Scores>> GetBestScoresAsync()
        {
            return await _context.Scores
                .Where(s => s.IsPublic)
                .OrderByDescending(s => s.Points)
                .ToListAsync();
        }

        public async Task<List<Scores>> GetMyScoresAsync(string userId)
        {
            return await _context.Scores
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.Points)
                .ToListAsync();
        }

        public async Task<Scores?> GetScoreByIdAsync(int id)
        {
            return await _context.Scores.FindAsync(id);
        }

        public async Task<Scores> PostScoreAsync(Scores score)
        {
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
            return score;
        }

        public async Task<bool> ChangeScoreVisibilityAsync(Scores score)
        {
            score.IsPublic = !score.IsPublic;
            return await _context.SaveChangesAsync() > 0;
        }
    
}
}
