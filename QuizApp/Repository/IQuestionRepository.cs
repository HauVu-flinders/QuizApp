using QuizApp.Models;
using System.Collections.ObjectModel;

namespace QuizApp.Services
{
    public interface IQuestionRepository
    {
        //ICollection<Question> GetAll();
        ICollection<Question> GetQuestionsByQuizId(int id);
        //void AddQuestion(Question question);
        //void UpdateQuestion(Question question);
       // void DeleteQuestion(int id);
    }
}
