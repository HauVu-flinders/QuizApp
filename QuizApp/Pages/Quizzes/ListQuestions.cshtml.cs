using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using QuizApp.Services;


namespace QuizApp.Pages.Quizzes
{
    public class ListQuestionsModel : PageModel
    {
        private IQuestionRepository _questionRepository;
        public ListQuestionsModel(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;

        }
        [BindProperty]
        public ICollection<Question> Questions { get; set; }
        public async Task OnGet(int id)
        {
                Questions = _questionRepository.GetQuestionsByQuizId(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (int.TryParse(HttpContext.Request.Query["id"].ToString(), out int quizId))
            {
                Questions = _questionRepository.GetQuestionsByQuizId(quizId);
            }

            int correctAnswersCount = 0;
            //loop through each question to get user answers
            foreach (var question in Questions)
            {
                string userAnswer = HttpContext.Request.Form[question.Id.ToString()];

                foreach (var answer in question.Answers)
                {     //compare user answers with correct answers
                    if (userAnswer == answer.Option && answer.AnswerKey != null) { correctAnswersCount++; }
                }
            }
            float result = 0;
            if (Questions.Count > 0)
            {
                result = (float)correctAnswersCount * 100 / Questions.Count;
            }
            else
            {
                return Content("Error: No questions available to calculate the result.");
            }

            return RedirectToPage("./Result", new { result });
        }
    }
}
