using System.ComponentModel.DataAnnotations;

namespace Our_Exam_2425.Model
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int PlayerScore { get; set; }
        public int BotScore { get; set; }
        public string Winner { get; set; } = "Draw";
        public DateTime CreatedAt { get; set; }
    }
}
