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
    public class ConditionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConditionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Condition
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Condition.Include(c => c.ConditionForm).Include(c => c.ConditionType).Include(c => c.Workout);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Condition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionModel = await _context.Condition
                .Include(c => c.ConditionForm)
                .Include(c => c.ConditionType)
                .Include(c => c.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conditionModel == null)
            {
                return NotFound();
            }

            return View(conditionModel);
        }

        // GET: Condition/Create
        public IActionResult Create()
        {
            ViewData["ConditionFormId"] = new SelectList(_context.ConditionForm, "Id", "ConditionName");
            ViewData["ConditionTypeId"] = new SelectList(_context.ConditionType, "Id", "ConditionType");
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description");
            return View();
        }

        // POST: Condition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConditionTypeId,ConditionFormId,WorkoutId")] ConditionModel conditionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conditionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionFormId"] = new SelectList(_context.ConditionForm, "Id", "ConditionName", conditionModel.ConditionFormId);
            ViewData["ConditionTypeId"] = new SelectList(_context.ConditionType, "Id", "ConditionType", conditionModel.ConditionTypeId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description", conditionModel.WorkoutId);
            return View(conditionModel);
        }

        // GET: Condition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionModel = await _context.Condition.FindAsync(id);
            if (conditionModel == null)
            {
                return NotFound();
            }
            ViewData["ConditionFormId"] = new SelectList(_context.ConditionForm, "Id", "ConditionName", conditionModel.ConditionFormId);
            ViewData["ConditionTypeId"] = new SelectList(_context.ConditionType, "Id", "ConditionType", conditionModel.ConditionTypeId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description", conditionModel.WorkoutId);
            return View(conditionModel);
        }

        // POST: Condition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConditionTypeId,ConditionFormId,WorkoutId")] ConditionModel conditionModel)
        {
            if (id != conditionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conditionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionModelExists(conditionModel.Id))
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
            ViewData["ConditionFormId"] = new SelectList(_context.ConditionForm, "Id", "ConditionName", conditionModel.ConditionFormId);
            ViewData["ConditionTypeId"] = new SelectList(_context.ConditionType, "Id", "ConditionType", conditionModel.ConditionTypeId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description", conditionModel.WorkoutId);
            return View(conditionModel);
        }

        // GET: Condition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionModel = await _context.Condition
                .Include(c => c.ConditionForm)
                .Include(c => c.ConditionType)
                .Include(c => c.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conditionModel == null)
            {
                return NotFound();
            }

            return View(conditionModel);
        }

        // POST: Condition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conditionModel = await _context.Condition.FindAsync(id);
            if (conditionModel != null)
            {
                _context.Condition.Remove(conditionModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionModelExists(int id)
        {
            return _context.Condition.Any(e => e.Id == id);
        }
    }
}
