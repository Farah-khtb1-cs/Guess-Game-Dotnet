using System.ComponentModel.DataAnnotations;

namespace Our_Exam_2425.Model
{
    public class GameBinding
    {
        [Range(1,10),Display(Name = "A")]
        [Required(ErrorMessage = "A is required.")]
        public int A { get; set; }


        [Range(1, 10), Display(Name = "B")]
        [Required(ErrorMessage = "B is required.")]
        public int B { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int PlayerScore { get; set; }
        public int BotScore { get; set; }
        public string Winner { get; set; } = "Draw";

        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}
