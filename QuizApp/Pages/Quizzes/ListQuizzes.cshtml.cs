using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Pages.Quizzes
{
    public class ListQuizzesModel : PageModel
    {
        private IQuizRepository _quizRepository;
        public ListQuizzesModel(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public IList<Quiz> Quizzes { get; set; }

        public async Task OnGetAsync()
        {
            Quizzes = _quizRepository.GetAll();
        }
    }
}
