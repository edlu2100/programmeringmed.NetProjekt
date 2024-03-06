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
    public class DisciplineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisciplineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Discipline
        public async Task<IActionResult> Index()
        {
            return View(await _context.Discipline.ToListAsync());
        }

        // GET: Discipline/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineModel = await _context.Discipline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplineModel == null)
            {
                return NotFound();
            }

            return View(disciplineModel);
        }

        // GET: Discipline/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Discipline/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DisciplineName")] DisciplineModel disciplineModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplineModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disciplineModel);
        }

        // GET: Discipline/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineModel = await _context.Discipline.FindAsync(id);
            if (disciplineModel == null)
            {
                return NotFound();
            }
            return View(disciplineModel);
        }

        // POST: Discipline/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DisciplineName")] DisciplineModel disciplineModel)
        {
            if (id != disciplineModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplineModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineModelExists(disciplineModel.Id))
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
            return View(disciplineModel);
        }

        // GET: Discipline/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineModel = await _context.Discipline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplineModel == null)
            {
                return NotFound();
            }

            return View(disciplineModel);
        }

        // POST: Discipline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplineModel = await _context.Discipline.FindAsync(id);
            if (disciplineModel != null)
            {
                _context.Discipline.Remove(disciplineModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplineModelExists(int id)
        {
            return _context.Discipline.Any(e => e.Id == id);
        }
    }
}
