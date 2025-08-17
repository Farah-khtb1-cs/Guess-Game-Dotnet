using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Our_Exam_2425.Model;
using Our_Exam_2425.Service;

namespace Our_Exam_2425.Pages
{
    public class GameResultModel : PageModel
    {
        private readonly IServices _services;

        public GameResultModel(IServices services)
        {
            _services = services;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public GameView GameView { get; set; } = new GameView();

        public List<Game> Games { get; set; } = new List<Game>();
        public async Task OnGet()
        {
            Game GameV = await _services.GetGameById(Id);
            GameView.PlayerScore = GameV.PlayerScore;
            GameView.BotScore = GameV.BotScore;
            GameView.Winner = GameV.Winner;
            GameView.A = GameV.A;
            GameView.B = GameV.B;
            GameView.X = GameV.X;
            GameView.Y = GameV.Y;
            GameView.CreatedAt = GameV.CreatedAt;

            Games = await _services.GetGames();
        }
    }
}
