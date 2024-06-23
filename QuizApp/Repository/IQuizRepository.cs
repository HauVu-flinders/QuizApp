using QuizApp.Models;

namespace QuizApp.Services
{
    public interface IQuizRepository
    {
        List<Quiz> GetAll();
    }
}
