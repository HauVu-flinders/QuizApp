namespace QuizApp.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string? Option  { get; set; }
        public int QuestionId {  get; set; }
        public AnswerKey? AnswerKey { get; set; }
        public Question? Question { get; set; }

    }
}
