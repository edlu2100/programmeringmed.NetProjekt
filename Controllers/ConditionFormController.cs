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
    public class ConditionFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConditionFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConditionForm
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConditionForm.ToListAsync());
        }

        // GET: ConditionForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionFormModel = await _context.ConditionForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conditionFormModel == null)
            {
                return NotFound();
            }

            return View(conditionFormModel);
        }

        // GET: ConditionForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConditionForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConditionName")] ConditionFormModel conditionFormModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conditionFormModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conditionFormModel);
        }

        // GET: ConditionForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionFormModel = await _context.ConditionForm.FindAsync(id);
            if (conditionFormModel == null)
            {
                return NotFound();
            }
            return View(conditionFormModel);
        }

        // POST: ConditionForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConditionName")] ConditionFormModel conditionFormModel)
        {
            if (id != conditionFormModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conditionFormModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionFormModelExists(conditionFormModel.Id))
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
            return View(conditionFormModel);
        }

        // GET: ConditionForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionFormModel = await _context.ConditionForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conditionFormModel == null)
            {
                return NotFound();
            }

            return View(conditionFormModel);
        }

        // POST: ConditionForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conditionFormModel = await _context.ConditionForm.FindAsync(id);
            if (conditionFormModel != null)
            {
                _context.ConditionForm.Remove(conditionFormModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionFormModelExists(int id)
        {
            return _context.ConditionForm.Any(e => e.Id == id);
        }
    }
}
