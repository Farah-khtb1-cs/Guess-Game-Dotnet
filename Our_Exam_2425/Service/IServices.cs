using Our_Exam_2425.Model;
using System.Runtime.CompilerServices;

namespace Our_Exam_2425.Service
{
    public interface IServices
    {
        public Task<List<Game>> GetGames();
        public Task<int> AddGame(GameBinding gameBinding);
        public Task<Game> GetGameById(int id);
    }
}
