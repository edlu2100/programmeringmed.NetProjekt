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
    public class WorkoutExerciseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutExerciseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutExercise
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkoutExercise.Include(w => w.Exercise).Include(w => w.Workout);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkoutExercise/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutExerciseModel = await _context.WorkoutExercise
                .Include(w => w.Exercise)
                .Include(w => w.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutExerciseModel == null)
            {
                return NotFound();
            }

            return View(workoutExerciseModel);
        }

        // GET: WorkoutExercise/Create
        public IActionResult Create(int workoutId)
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "ExerciseName");
            ViewData["WorkoutId"] = workoutId;
            return View();
        }

        // POST: WorkoutExercise/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkoutId,ExerciseId")] WorkoutExerciseModel workoutExerciseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutExerciseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "ExerciseName", workoutExerciseModel.ExerciseId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "WorkoutName", workoutExerciseModel.WorkoutId);
            return View(workoutExerciseModel);
        }

        // GET: WorkoutExercise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutExerciseModel = await _context.WorkoutExercise.FindAsync(id);
            if (workoutExerciseModel == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Description", workoutExerciseModel.ExerciseId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description", workoutExerciseModel.WorkoutId);
            return View(workoutExerciseModel);
        }

        // POST: WorkoutExercise/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkoutId,ExerciseId")] WorkoutExerciseModel workoutExerciseModel)
        {
            if (id != workoutExerciseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutExerciseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutExerciseModelExists(workoutExerciseModel.Id))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Description", workoutExerciseModel.ExerciseId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description", workoutExerciseModel.WorkoutId);
            return View(workoutExerciseModel);
        }

        // GET: WorkoutExercise/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutExerciseModel = await _context.WorkoutExercise
                .Include(w => w.Exercise)
                .Include(w => w.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutExerciseModel == null)
            {
                return NotFound();
            }

            return View(workoutExerciseModel);
        }

        // POST: WorkoutExercise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutExerciseModel = await _context.WorkoutExercise.FindAsync(id);
            if (workoutExerciseModel != null)
            {
                _context.WorkoutExercise.Remove(workoutExerciseModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutExerciseModelExists(int id)
        {
            return _context.WorkoutExercise.Any(e => e.Id == id);
        }
    }
}
