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
    public class AudioEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AudioEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AudioEntries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AudioEntry.Include(a => a.Albums).Include(a => a.AudioLists);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AudioEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AudioEntry == null)
            {
                return NotFound();
            }

            var audioEntry = await _context.AudioEntry
                .Include(a => a.Albums)
                .Include(a => a.AudioLists)
                .FirstOrDefaultAsync(m => m.AudioEntryId == id);
            if (audioEntry == null)
            {
                return NotFound();
            }

            return View(audioEntry);
        }

        // GET: AudioEntries/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title");
            ViewData["AudioListId"] = new SelectList(_context.Set<AudioList>(), "AudioListId", "AudioListName");
            return View();
        }

        // POST: AudioEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AudioEntryId,position,AlbumId,AudioListId")] AudioEntry audioEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audioEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "ArtistName", audioEntry.AlbumId);
            ViewData["AudioListId"] = new SelectList(_context.Set<AudioList>(), "AudioListId", "AudioListName", audioEntry.AudioListId);
            return View(audioEntry);
        }

        // GET: AudioEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AudioEntry == null)
            {
                return NotFound();
            }

            var audioEntry = await _context.AudioEntry.FindAsync(id);
            if (audioEntry == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title", audioEntry.AlbumId);
            ViewData["AudioListId"] = new SelectList(_context.Set<AudioList>(), "AudioListId", "AudioListName", audioEntry.AudioListId);
            return View(audioEntry);
        }

        // POST: AudioEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AudioEntryId,position,AlbumId,AudioListId")] AudioEntry audioEntry)
        {
            if (id != audioEntry.AudioEntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audioEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudioEntryExists(audioEntry.AudioEntryId))
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
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Title", audioEntry.AlbumId);
            ViewData["AudioListId"] = new SelectList(_context.Set<AudioList>(), "AudioListId", "AudioListName", audioEntry.AudioListId);
            return View(audioEntry);
        }

        // GET: AudioEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AudioEntry == null)
            {
                return NotFound();
            }

            var audioEntry = await _context.AudioEntry
                .Include(a => a.Albums)
                .Include(a => a.AudioLists)
                .FirstOrDefaultAsync(m => m.AudioEntryId == id);
            if (audioEntry == null)
            {
                return NotFound();
            }

            return View(audioEntry);
        }

        // POST: AudioEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AudioEntry == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AudioEntry'  is null.");
            }
            var audioEntry = await _context.AudioEntry.FindAsync(id);
            if (audioEntry != null)
            {
                _context.AudioEntry.Remove(audioEntry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudioEntryExists(int id)
        {
          return (_context.AudioEntry?.Any(e => e.AudioEntryId == id)).GetValueOrDefault();
        }
    }
}
