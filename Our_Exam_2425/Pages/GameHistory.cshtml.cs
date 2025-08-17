using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Our_Exam_2425.Model;
using Our_Exam_2425.Service;
using System.Runtime.CompilerServices;

namespace Our_Exam_2425.Pages
{
    public class GameHistoryModel : PageModel
    {
        private readonly IServices _services;

        public GameHistoryModel(IServices services)
        {
            _services = services;
        }
        public List<Game> Games { get; set; } = new List<Game>();
        public async Task  OnGet()
        {
            Games = await _services.GetGames();
        }
    }
}
