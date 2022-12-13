using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quizt.Data;
using quizt.Models;
using System.Diagnostics;

namespace quizt.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.onlineexam != null ?
                         View(await _context.onlineexam.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.onlineexam'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}