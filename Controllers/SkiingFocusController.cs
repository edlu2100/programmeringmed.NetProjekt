using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using programmeringmed.NetProjekt.Data;
using programmeringmed.NetProjekt.Models;

namespace programmeringmed.NetProjekt.Controllers
{
    public class SkiingFocusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkiingFocusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkiingFocus
        public async Task<IActionResult> Index()
        {
            return View(await _context.SkiingFocus.ToListAsync());
        }

        // GET: SkiingFocus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiingFocusModel = await _context.SkiingFocus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skiingFocusModel == null)
            {
                return NotFound();
            }

            return View(skiingFocusModel);
        }

        // GET: SkiingFocus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkiingFocus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FocusName")] SkiingFocusModel skiingFocusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skiingFocusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skiingFocusModel);
        }

        // GET: SkiingFocus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiingFocusModel = await _context.SkiingFocus.FindAsync(id);
            if (skiingFocusModel == null)
            {
                return NotFound();
            }
            return View(skiingFocusModel);
        }

        // POST: SkiingFocus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FocusName")] SkiingFocusModel skiingFocusModel)
        {
            if (id != skiingFocusModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skiingFocusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkiingFocusModelExists(skiingFocusModel.Id))
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
            return View(skiingFocusModel);
        }

        // GET: SkiingFocus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiingFocusModel = await _context.SkiingFocus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skiingFocusModel == null)
            {
                return NotFound();
            }

            return View(skiingFocusModel);
        }

        // POST: SkiingFocus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skiingFocusModel = await _context.SkiingFocus.FindAsync(id);
            if (skiingFocusModel != null)
            {
                _context.SkiingFocus.Remove(skiingFocusModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkiingFocusModelExists(int id)
        {
            return _context.SkiingFocus.Any(e => e.Id == id);
        }
    }
}
