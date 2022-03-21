#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bug_Tracker.Data;
using Bug_Tracker.Models;

namespace Bug_Tracker.Controllers
{
    public class BugModelsController : Controller
    {
        private readonly Bug_TrackerContext _context;

        public BugModelsController(Bug_TrackerContext context)
        {
            _context = context;
        }

        // GET: BugModels
        public async Task<IActionResult> Index(string searchString)
        {
            var bugs = from b in _context.BugModel
                       select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                bugs = bugs.Where(b => b.Name!.Contains(searchString));
            }

            return View(await _context.BugModel.ToListAsync());
        }

        // GET: BugModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.BugModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bugModel == null)
            {
                return NotFound();
            }

            return View(bugModel);
        }

        // GET: BugModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BugModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,label,active,resolved")] BugModel bugModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bugModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bugModel);
        }

        // GET: BugModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.BugModel.FindAsync(id);
            if (bugModel == null)
            {
                return NotFound();
            }
            return View(bugModel);
        }

        // POST: BugModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,label,active,resolved")] BugModel bugModel)
        {
            if (id != bugModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bugModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugModelExists(bugModel.Id))
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
            return View(bugModel);
        }

        // GET: BugModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.BugModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bugModel == null)
            {
                return NotFound();
            }

            return View(bugModel);
        }

        // POST: BugModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bugModel = await _context.BugModel.FindAsync(id);
            _context.BugModel.Remove(bugModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugModelExists(int id)
        {
            return _context.BugModel.Any(e => e.Id == id);
        }
    }
}
