using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Our_Exam_2425.Model;
using Our_Exam_2425.Service;

namespace Our_Exam_2425.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IServices _services;
        public IndexModel(ILogger<IndexModel> logger, IServices services)
        {
            _logger = logger;
            _services = services;
        }
        [BindProperty]
        public GameBinding GameBinding { get; set; } = new GameBinding();


        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(int X, int Y)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(GameBinding.A >= GameBinding.B || GameBinding.B%2 != 0)
            {
                ModelState.AddModelError("", "A MUST BE LESS THAN B AND B%2 == 0");
                return Page();
            }
            GameBinding.PlayerScore = GameBinding.A + GameBinding.B;
            GameBinding.BotScore = X + Y;

            if (GameBinding.A + GameBinding.B > X + Y)
                GameBinding.Winner = "Player";
            else
                GameBinding.Winner = "Bot";
            var id = await _services.AddGame(GameBinding);
            if (id > 0)
            {
                return RedirectToPage("GameResult", new { id = id });
            }
            return Page();
        }

    }
}
