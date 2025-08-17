using Microsoft.EntityFrameworkCore;
using Our_Exam_2425.Data;
using Our_Exam_2425.Model;

namespace Our_Exam_2425.Service
{
    public class Services : IServices
    {
        private readonly AppDbContext _context;

        public Services(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Game>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }
        public async Task<int> AddGame(GameBinding gameBinding)
        {
            var game = new Game
            {
                A = gameBinding.A,
                B = gameBinding.B,
                X = gameBinding.X,
                Y = gameBinding.Y,
                PlayerScore = gameBinding.PlayerScore,
                BotScore = gameBinding.BotScore,
                Winner = gameBinding.Winner,
                CreatedAt = gameBinding.CreatedAt
            };
             _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games.FindAsync(id);
        }
    }
}
