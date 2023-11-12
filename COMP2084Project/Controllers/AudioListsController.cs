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
    public class AudioListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AudioListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AudioLists
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return _context.AudioList != null ? 
                          View(await _context.AudioList.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AudioList'  is null.");
        }

        // GET: AudioLists/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AudioList == null)
            {
                return NotFound();
            }

            var audioList = await _context.AudioList
                .FirstOrDefaultAsync(m => m.AudioListId == id);
            if (audioList == null)
            {
                return NotFound();
            }

            return View(audioList);
        }

        // GET: AudioLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AudioLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AudioListId,AudioListName,AudioListDescription")] AudioList audioList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audioList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audioList);
        }

        // GET: AudioLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AudioList == null)
            {
                return NotFound();
            }

            var audioList = await _context.AudioList.FindAsync(id);
            if (audioList == null)
            {
                return NotFound();
            }
            return View(audioList);
        }

        // POST: AudioLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AudioListId,AudioListName,AudioListDescription")] AudioList audioList)
        {
            if (id != audioList.AudioListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audioList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudioListExists(audioList.AudioListId))
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
            return View(audioList);
        }

        // GET: AudioLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AudioList == null)
            {
                return NotFound();
            }

            var audioList = await _context.AudioList
                .FirstOrDefaultAsync(m => m.AudioListId == id);
            if (audioList == null)
            {
                return NotFound();
            }

            return View(audioList);
        }

        // POST: AudioLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AudioList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AudioList'  is null.");
            }
            var audioList = await _context.AudioList.FindAsync(id);
            if (audioList != null)
            {
                _context.AudioList.Remove(audioList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudioListExists(int id)
        {
          return (_context.AudioList?.Any(e => e.AudioListId == id)).GetValueOrDefault();
        }
    }
}
