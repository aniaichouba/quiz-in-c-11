using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using quizt.Data;
using quizt.Models;

namespace quizt.Controllers
{
    public class OnlineExamClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OnlineExamClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OnlineExamClasses
        public async Task<IActionResult> Index()
        {
              return _context.onlineexam != null ? 
                          View(await _context.onlineexam.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.onlineexam'  is null.");
        }

        // GET: OnlineExamClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.onlineexam == null)
            {
                return NotFound();
            }

            var onlineExamClass = await _context.onlineexam
                .FirstOrDefaultAsync(m => m.Qid == id);
            if (onlineExamClass == null)
            {
                return NotFound();
            }

            return View(onlineExamClass);
        }

        // GET: OnlineExamClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OnlineExamClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Qid,Question,option1,option2,option3,option4,Correctans")] OnlineExamClass onlineExamClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onlineExamClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onlineExamClass);
        }

        // GET: OnlineExamClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.onlineexam == null)
            {
                return NotFound();
            }

            var onlineExamClass = await _context.onlineexam.FindAsync(id);
            if (onlineExamClass == null)
            {
                return NotFound();
            }
            return View(onlineExamClass);
        }

        // POST: OnlineExamClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Qid,Question,option1,option2,option3,option4,Correctans")] OnlineExamClass onlineExamClass)
        {
            if (id != onlineExamClass.Qid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onlineExamClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlineExamClassExists(onlineExamClass.Qid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(onlineExamClass);
        }

        // GET: OnlineExamClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.onlineexam == null)
            {
                return NotFound();
            }

            var onlineExamClass = await _context.onlineexam
                .FirstOrDefaultAsync(m => m.Qid == id);
            if (onlineExamClass == null)
            {
                return NotFound();
            }

            return View(onlineExamClass);
        }

        // POST: OnlineExamClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.onlineexam == null)
            {
                return Problem("Entity set 'ApplicationDbContext.onlineexam'  is null.");
            }
            var onlineExamClass = await _context.onlineexam.FindAsync(id);
            if (onlineExamClass != null)
            {
                _context.onlineexam.Remove(onlineExamClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlineExamClassExists(int id)
        {
          return (_context.onlineexam?.Any(e => e.Qid == id)).GetValueOrDefault();
        }
    }
}
