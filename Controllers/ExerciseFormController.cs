using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using programmeringmed.NetProjekt.Data;
using programmeringmed.NetProjekt.Models;

namespace programmeringmed.NetProjekt.Controllers
{
    [Authorize]
    public class ExerciseFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExerciseForm
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExerciseForm.ToListAsync());
        }

        // GET: ExerciseForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseFormModel = await _context.ExerciseForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseFormModel == null)
            {
                return NotFound();
            }

            return View(exerciseFormModel);
        }

        // GET: ExerciseForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExerciseForm")] ExerciseFormModel exerciseFormModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseFormModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseFormModel);
        }

        // GET: ExerciseForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseFormModel = await _context.ExerciseForm.FindAsync(id);
            if (exerciseFormModel == null)
            {
                return NotFound();
            }
            return View(exerciseFormModel);
        }

        // POST: ExerciseForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExerciseForm")] ExerciseFormModel exerciseFormModel)
        {
            if (id != exerciseFormModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseFormModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseFormModelExists(exerciseFormModel.Id))
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
            return View(exerciseFormModel);
        }

        // GET: ExerciseForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseFormModel = await _context.ExerciseForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseFormModel == null)
            {
                return NotFound();
            }

            return View(exerciseFormModel);
        }

        // POST: ExerciseForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseFormModel = await _context.ExerciseForm.FindAsync(id);
            if (exerciseFormModel != null)
            {
                _context.ExerciseForm.Remove(exerciseFormModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseFormModelExists(int id)
        {
            return _context.ExerciseForm.Any(e => e.Id == id);
        }
    }
}
