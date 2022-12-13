using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using quizt.Data;
using quizt.Models;

namespace quizt.Views
{
    public class IndexModel : PageModel
    {
        
        private readonly ApplicationDbContext _acc;

        public IndexModel(ApplicationDbContext acc)
        {
            
            this._acc = acc;
        }
        public IEnumerable<OnlineExamClass> displayresults { get; set; }
        public async Task OnGet()
        {
            displayresults = await _acc.onlineexam.ToListAsync();
        }
    }
}
