using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP2084Project.Data;
using COMP2084Project.Models;

namespace COMP2084Project.Controllers
{
    public class ScreenGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScreenGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScreenGenres
        public async Task<IActionResult> Index()
        {
              return _context.ScreenGenres != null ? 
                          View(await _context.ScreenGenres.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ScreenGenres'  is null.");
        }

        // GET: ScreenGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ScreenGenres == null)
            {
                return NotFound();
            }

            var screenGenre = await _context.ScreenGenres
                .FirstOrDefaultAsync(m => m.ScreenGenreId == id);
            if (screenGenre == null)
            {
                return NotFound();
            }

            return View(screenGenre);
        }

        // GET: ScreenGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScreenGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScreenGenreId,Name")] ScreenGenre screenGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(screenGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(screenGenre);
        }

        // GET: ScreenGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ScreenGenres == null)
            {
                return NotFound();
            }

            var screenGenre = await _context.ScreenGenres.FindAsync(id);
            if (screenGenre == null)
            {
                return NotFound();
            }
            return View(screenGenre);
        }

        // POST: ScreenGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScreenGenreId,Name")] ScreenGenre screenGenre)
        {
            if (id != screenGenre.ScreenGenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screenGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreenGenreExists(screenGenre.ScreenGenreId))
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
            return View(screenGenre);
        }

        // GET: ScreenGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ScreenGenres == null)
            {
                return NotFound();
            }

            var screenGenre = await _context.ScreenGenres
                .FirstOrDefaultAsync(m => m.ScreenGenreId == id);
            if (screenGenre == null)
            {
                return NotFound();
            }

            return View(screenGenre);
        }

        // POST: ScreenGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ScreenGenres == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ScreenGenres'  is null.");
            }
            var screenGenre = await _context.ScreenGenres.FindAsync(id);
            if (screenGenre != null)
            {
                _context.ScreenGenres.Remove(screenGenre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreenGenreExists(int id)
        {
          return (_context.ScreenGenres?.Any(e => e.ScreenGenreId == id)).GetValueOrDefault();
        }
    }
}
