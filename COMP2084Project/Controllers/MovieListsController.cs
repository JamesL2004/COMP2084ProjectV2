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
    public class MovieListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieLists
        public async Task<IActionResult> Index()
        {
              return _context.MovieList_1 != null ? 
                          View(await _context.MovieList_1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MovieList_1'  is null.");
        }

        // GET: MovieLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieList_1 == null)
            {
                return NotFound();
            }

            var movieList = await _context.MovieList_1
                .FirstOrDefaultAsync(m => m.MovieListId == id);
            if (movieList == null)
            {
                return NotFound();
            }

            return View(movieList);
        }

        // GET: MovieLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieListId,MovieListName,MovieListDescription")] MovieList movieList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieList);
        }

        // GET: MovieLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieList_1 == null)
            {
                return NotFound();
            }

            var movieList = await _context.MovieList_1.FindAsync(id);
            if (movieList == null)
            {
                return NotFound();
            }
            return View(movieList);
        }

        // POST: MovieLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieListId,MovieListName,MovieListDescription")] MovieList movieList)
        {
            if (id != movieList.MovieListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieListExists(movieList.MovieListId))
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
            return View(movieList);
        }

        // GET: MovieLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieList_1 == null)
            {
                return NotFound();
            }

            var movieList = await _context.MovieList_1
                .FirstOrDefaultAsync(m => m.MovieListId == id);
            if (movieList == null)
            {
                return NotFound();
            }

            return View(movieList);
        }

        // POST: MovieLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieList_1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MovieList_1'  is null.");
            }
            var movieList = await _context.MovieList_1.FindAsync(id);
            if (movieList != null)
            {
                _context.MovieList_1.Remove(movieList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieListExists(int id)
        {
          return (_context.MovieList_1?.Any(e => e.MovieListId == id)).GetValueOrDefault();
        }
    }
}
