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
    public class MovieEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieEntries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MovieEntry_1.Include(m => m.Movie).Include(m => m.MovieLists);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MovieEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieEntry_1 == null)
            {
                return NotFound();
            }

            var movieEntry = await _context.MovieEntry_1
                .Include(m => m.Movie)
                .Include(m => m.MovieLists)
                .FirstOrDefaultAsync(m => m.MovieEntryId == id);
            if (movieEntry == null)
            {
                return NotFound();
            }

            return View(movieEntry);
        }

        // GET: MovieEntries/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Director");
            ViewData["MovieListId"] = new SelectList(_context.Set<MovieList>(), "MovieListId", "MovieListId");
            return View();
        }

        // POST: MovieEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieEntryId,position,MovieId,MovieListId")] MovieEntry movieEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Director", movieEntry.MovieId);
            ViewData["MovieListId"] = new SelectList(_context.Set<MovieList>(), "MovieListId", "MovieListId", movieEntry.MovieListId);
            return View(movieEntry);
        }

        // GET: MovieEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieEntry_1 == null)
            {
                return NotFound();
            }

            var movieEntry = await _context.MovieEntry_1.FindAsync(id);
            if (movieEntry == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Director", movieEntry.MovieId);
            ViewData["MovieListId"] = new SelectList(_context.Set<MovieList>(), "MovieListId", "MovieListId", movieEntry.MovieListId);
            return View(movieEntry);
        }

        // POST: MovieEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieEntryId,position,MovieId,MovieListId")] MovieEntry movieEntry)
        {
            if (id != movieEntry.MovieEntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieEntryExists(movieEntry.MovieEntryId))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Director", movieEntry.MovieId);
            ViewData["MovieListId"] = new SelectList(_context.Set<MovieList>(), "MovieListId", "MovieListId", movieEntry.MovieListId);
            return View(movieEntry);
        }

        // GET: MovieEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieEntry_1 == null)
            {
                return NotFound();
            }

            var movieEntry = await _context.MovieEntry_1
                .Include(m => m.Movie)
                .Include(m => m.MovieLists)
                .FirstOrDefaultAsync(m => m.MovieEntryId == id);
            if (movieEntry == null)
            {
                return NotFound();
            }

            return View(movieEntry);
        }

        // POST: MovieEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieEntry_1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MovieEntry_1'  is null.");
            }
            var movieEntry = await _context.MovieEntry_1.FindAsync(id);
            if (movieEntry != null)
            {
                _context.MovieEntry_1.Remove(movieEntry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieEntryExists(int id)
        {
          return (_context.MovieEntry_1?.Any(e => e.MovieEntryId == id)).GetValueOrDefault();
        }
    }
}
