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
    public class ShowListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShowLists
        public async Task<IActionResult> Index()
        {
              return _context.ShowList_1 != null ? 
                          View(await _context.ShowList_1.ToListAsync()) : 
                          Problem("Entity set 'ApplicationDbContext.ShowList_1'  is null.");
        }

        // GET: ShowLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShowList_1 == null)
            {
                return NotFound();
            }

            var showList = await _context.ShowList_1
                .FirstOrDefaultAsync(m => m.ShowListId == id);
            if (showList == null)
            {
                return NotFound();
            }

            return View(showList);
        }

        // GET: ShowLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShowLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowListId,ShowListName,ShowListDescription")] ShowList showList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showList);
        }

        // GET: ShowLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShowList_1 == null)
            {
                return NotFound();
            }

            var showList = await _context.ShowList_1.FindAsync(id);
            if (showList == null)
            {
                return NotFound();
            }
            return View(showList);
        }

        // POST: ShowLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowListId,ShowListName,ShowListDescription")] ShowList showList)
        {
            if (id != showList.ShowListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowListExists(showList.ShowListId))
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
            return View(showList);
        }

        // GET: ShowLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShowList_1 == null)
            {
                return NotFound();
            }

            var showList = await _context.ShowList_1
                .FirstOrDefaultAsync(m => m.ShowListId == id);
            if (showList == null)
            {
                return NotFound();
            }

            return View(showList);
        }

        // POST: ShowLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShowList_1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShowList_1'  is null.");
            }
            var showList = await _context.ShowList_1.FindAsync(id);
            if (showList != null)
            {
                _context.ShowList_1.Remove(showList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowListExists(int id)
        {
          return (_context.ShowList_1?.Any(e => e.ShowListId == id)).GetValueOrDefault();
        }
    }
}
