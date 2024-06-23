using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private QuizAppDbContext _context;

        public QuestionRepository (QuizAppDbContext context)
        {
            _context = context;
        }
        public ICollection<Question> GetQuestionsByQuizId(int quizId)
        {
            return _context.Questions
                    .Where(q => q.QuizId == quizId)
                    .Include(q => q.Answers)
                        .ThenInclude(a => a.AnswerKey)
                    .ToList();
        }


    }
}
