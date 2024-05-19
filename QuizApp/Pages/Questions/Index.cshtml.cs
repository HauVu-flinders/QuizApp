using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppDbContext _context;

        public IndexModel(QuizApp.Data.QuizAppDbContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Question = await _context.Questions
                .Include(q => q.Quiz).ToListAsync();
        }
    }
}
