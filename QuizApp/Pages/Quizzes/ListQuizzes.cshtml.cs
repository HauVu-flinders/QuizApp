using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Models;

namespace QuizApp.Pages.Quizzes
{
    public class ListQuizzesModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppDbContext _context;

        public ListQuizzesModel(QuizApp.Data.QuizAppDbContext context)
        {
            _context = context;
        }

        public IList<Quiz> Quiz { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Quiz = await _context.Quizzes.ToListAsync();
        }
    }
}
