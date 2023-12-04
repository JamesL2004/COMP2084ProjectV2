using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP2084Project.Data;
using COMP2084Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace COMP2084Project.Controllers
{
    [Authorize]
    public class ShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shows
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shows.Include(s => s.ScreenGenre).OrderBy(s => s.Title);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Shows/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shows == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.ScreenGenre)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["ScreenGenreId"] = new SelectList(_context.ScreenGenres.OrderBy(c => c.Name), "ScreenGenreId", "Name");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,Title,ShowCreator,ScreenGenreId,rating,review")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScreenGenreId"] = new SelectList(_context.ScreenGenres, "ScreenGenreId", "ScreenGenreId", show.ScreenGenreId);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shows == null)
            {
                return NotFound();
            }

            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["ScreenGenreId"] = new SelectList(_context.ScreenGenres, "ScreenGenreId", "Name", show.ScreenGenreId);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowId,Title,ShowCreator,ScreenGenreId,rating,review")] Show show)
        {
            if (id != show.ShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowId))
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
            ViewData["ScreenGenreId"] = new SelectList(_context.ScreenGenres, "ScreenGenreId", "ScreenGenreId", show.ScreenGenreId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shows == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.ScreenGenre)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shows == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shows'  is null.");
            }
            var show = await _context.Shows.FindAsync(id);
            if (show != null)
            {
                _context.Shows.Remove(show);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
          return (_context.Shows?.Any(e => e.ShowId == id)).GetValueOrDefault();
        }
    }
}
