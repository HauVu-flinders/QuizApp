
namespace QuizApp.Models
{
    public class AnswerKey
    {
        public int Id { get; set; }
        public int Key {  get; set; }
        public int? AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
