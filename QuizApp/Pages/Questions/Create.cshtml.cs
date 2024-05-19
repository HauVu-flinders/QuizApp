using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppDbContext _context;

        public CreateModel(QuizApp.Data.QuizAppDbContext context)
        {
            _context = context;
            
           
        }

        public IActionResult OnGet()
        {
        ViewData["QuizId"] = new SelectList(_context.Set<Quiz>(), "Id", "Id");
            return Page();
        }
        [BindProperty]
        public Question Question { get; set; } = default!;
       
        [BindProperty]
        public List<Answer> Answers{ get; set; }

        [BindProperty]
        public AnswerKey AnswerKey { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //add a question to db
            _context.Questions.Add(Question);
            await _context.SaveChangesAsync();

            //add answers to db

            for (int i = 0; i < Answers.Count; i++)
            {
                Answers[i].QuestionId = Question.Id;
                _context.Answers.Add(Answers[i]);
                await _context.SaveChangesAsync();
                if (AnswerKey.Key - 1 == i)
                {
                    //add a key to db 
                    AnswerKey.AnswerId = Answers[i].Id;
                    _context.AnswersKeys.Add(AnswerKey);
                    await _context.SaveChangesAsync();
                }
            }
          
            return RedirectToPage("./Index");
        }
    }
}
