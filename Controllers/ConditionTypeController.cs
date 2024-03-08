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
    public class ConditionTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConditionTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConditionType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConditionType.ToListAsync());
        }

        // GET: ConditionType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionTypeModel = await _context.ConditionType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conditionTypeModel == null)
            {
                return NotFound();
            }

            return View(conditionTypeModel);
        }

        // GET: ConditionType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConditionType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConditionType")] ConditionTypeModel conditionTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conditionTypeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conditionTypeModel);
        }

        // GET: ConditionType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionTypeModel = await _context.ConditionType.FindAsync(id);
            if (conditionTypeModel == null)
            {
                return NotFound();
            }
            return View(conditionTypeModel);
        }

        // POST: ConditionType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConditionType")] ConditionTypeModel conditionTypeModel)
        {
            if (id != conditionTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conditionTypeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionTypeModelExists(conditionTypeModel.Id))
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
            return View(conditionTypeModel);
        }

        // GET: ConditionType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionTypeModel = await _context.ConditionType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conditionTypeModel == null)
            {
                return NotFound();
            }

            return View(conditionTypeModel);
        }

        // POST: ConditionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conditionTypeModel = await _context.ConditionType.FindAsync(id);
            if (conditionTypeModel != null)
            {
                _context.ConditionType.Remove(conditionTypeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionTypeModelExists(int id)
        {
            return _context.ConditionType.Any(e => e.Id == id);
        }
    }
}
