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
    public class AudioGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AudioGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AudioGenres
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return _context.AudioGenres != null ? 
                          View(await _context.AudioGenres.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AudioGenres'  is null.");
        }

        // GET: AudioGenres/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AudioGenres == null)
            {
                return NotFound();
            }

            var audioGenre = await _context.AudioGenres
                .FirstOrDefaultAsync(m => m.AudioGenreId == id);
            if (audioGenre == null)
            {
                return NotFound();
            }

            return View(audioGenre);
        }

        // GET: AudioGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AudioGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AudioGenreId,Name")] AudioGenre audioGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audioGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audioGenre);
        }

        // GET: AudioGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AudioGenres == null)
            {
                return NotFound();
            }

            var audioGenre = await _context.AudioGenres.FindAsync(id);
            if (audioGenre == null)
            {
                return NotFound();
            }
            return View(audioGenre);
        }

        // POST: AudioGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AudioGenreId,Name")] AudioGenre audioGenre)
        {
            if (id != audioGenre.AudioGenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audioGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudioGenreExists(audioGenre.AudioGenreId))
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
            return View(audioGenre);
        }

        // GET: AudioGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AudioGenres == null)
            {
                return NotFound();
            }

            var audioGenre = await _context.AudioGenres
                .FirstOrDefaultAsync(m => m.AudioGenreId == id);
            if (audioGenre == null)
            {
                return NotFound();
            }

            return View(audioGenre);
        }

        // POST: AudioGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AudioGenres == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AudioGenres'  is null.");
            }
            var audioGenre = await _context.AudioGenres.FindAsync(id);
            if (audioGenre != null)
            {
                _context.AudioGenres.Remove(audioGenre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudioGenreExists(int id)
        {
          return (_context.AudioGenres?.Any(e => e.AudioGenreId == id)).GetValueOrDefault();
        }
    }
}
