using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Data;
using Microsoft.EntityFrameworkCore;


namespace QuizApp.Pages.Quizzes
{
    public class ListQuestionsModel : PageModel
    {
        private QuizAppDbContext _context;

        public ListQuestionsModel(QuizAppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Question> Questions { get; set; }
        public async Task OnGet()
        {
            if (int.TryParse(HttpContext.Request.Query["id"].ToString(), out int quizId))
            {
                Questions = await _context.Questions
                    .Where(q => q.QuizId == quizId)
                    .Include(q => q.Answers)
                         .ThenInclude(a => a.AnswerKey)
                    .ToListAsync();

            }

        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //if (int.TryParse(HttpContext.Request.Query["id"].ToString(), out int quizId))
            //{
            //    Questions = await _context.Questions
            //        .Where(q => q.QuizId == quizId)
            //        .Include(q => q.Answers)
            //            .ThenInclude(a => a.AnswerKey)
            //        .ToListAsync();
            //}
            int count = 0;
            //loop through each question to get user answers
            foreach (var question in Questions)
            {
                string userAnswer = HttpContext.Request.Form[question.Id.ToString()];
                
                foreach(var answer in question.Answers)
                    {     //compare user answers with correct answers
                        if (userAnswer == answer.Option && answer.AnswerKey != null) { count++;}
                    }
            }
            float result = (float)count * 100 / Questions.Count;
            return RedirectToPage("./Result", new { result });
        }
    }
}
