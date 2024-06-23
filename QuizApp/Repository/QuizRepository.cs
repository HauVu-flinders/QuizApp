using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private QuizAppDbContext _context;

        public QuizRepository (QuizAppDbContext context)
        {
            _context = context;
        }
        public List<Quiz> GetAll()
        {
           return _context.Quizzes.ToList();
        }
    }
}

