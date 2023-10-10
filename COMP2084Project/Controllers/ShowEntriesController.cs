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
    public class ShowEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShowEntries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ShowEntry_1.Include(s => s.ShowLists).Include(s => s.Shows);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ShowEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShowEntry_1 == null)
            {
                return NotFound();
            }

            var showEntry = await _context.ShowEntry_1
                .Include(s => s.ShowLists)
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.ShowEntryId == id);
            if (showEntry == null)
            {
                return NotFound();
            }

            return View(showEntry);
        }

        // GET: ShowEntries/Create
        public IActionResult Create()
        {
            ViewData["ShowListId"] = new SelectList(_context.Set<ShowList>(), "ShowListId", "ShowListName");
            ViewData["ShowId"] = new SelectList(_context.Shows, "ShowId", "Title");
            return View();
        }

        // POST: ShowEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowEntryId,position,ShowId,ShowListId")] ShowEntry showEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowListId"] = new SelectList(_context.Set<ShowList>(), "ShowListId", "ShowListId", showEntry.ShowListId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "ShowId", "ShowCreator", showEntry.ShowId);
            return View(showEntry);
        }

        // GET: ShowEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShowEntry_1 == null)
            {
                return NotFound();
            }

            var showEntry = await _context.ShowEntry_1.FindAsync(id);
            if (showEntry == null)
            {
                return NotFound();
            }
            ViewData["ShowListId"] = new SelectList(_context.Set<ShowList>(), "ShowListId", "ShowListName", showEntry.ShowListId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "ShowId", "Title", showEntry.ShowId);
            return View(showEntry);
        }

        // POST: ShowEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowEntryId,position,ShowId,ShowListId")] ShowEntry showEntry)
        {
            if (id != showEntry.ShowEntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowEntryExists(showEntry.ShowEntryId))
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
            ViewData["ShowListId"] = new SelectList(_context.Set<ShowList>(), "ShowListId", "ShowListId", showEntry.ShowListId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "ShowId", "ShowCreator", showEntry.ShowId);
            return View(showEntry);
        }

        // GET: ShowEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShowEntry_1 == null)
            {
                return NotFound();
            }

            var showEntry = await _context.ShowEntry_1
                .Include(s => s.ShowLists)
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.ShowEntryId == id);
            if (showEntry == null)
            {
                return NotFound();
            }

            return View(showEntry);
        }

        // POST: ShowEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShowEntry_1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShowEntry_1'  is null.");
            }
            var showEntry = await _context.ShowEntry_1.FindAsync(id);
            if (showEntry != null)
            {
                _context.ShowEntry_1.Remove(showEntry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowEntryExists(int id)
        {
          return (_context.ShowEntry_1?.Any(e => e.ShowEntryId == id)).GetValueOrDefault();
        }
    }
}
