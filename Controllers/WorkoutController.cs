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
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Workout
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Workout.Include(w => w.BodyPart).Include(w => w.ExerciseForm);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Workout/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutModel = await _context.Workout
                .Include(w => w.BodyPart)
                .Include(w => w.ExerciseForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutModel == null)
            {
                return NotFound();
            }

            return View(workoutModel);
        }

        // GET: Workout/Create
        public IActionResult Create()
        {
            ViewData["BodyPartId"] = new SelectList(_context.BodyPart, "Id", "BodyPart");
            ViewData["ExerciseFormId"] = new SelectList(_context.ExerciseForm, "Id", "ExerciseForm");
            return View();
        }

        // POST: Workout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkoutName,Description,Date,Completed,BodyPartId,ExerciseFormId")] WorkoutModel workoutModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutModel);
                await _context.SaveChangesAsync();

                // Redirect till WorkoutExercise/Create och inkludera id för det skapade träningspasset
                return RedirectToAction("Create", "WorkoutExercise", new { workoutId = workoutModel.Id });
            }
            ViewData["BodyPartId"] = new SelectList(_context.BodyPart, "Id", "BodyPart", workoutModel.BodyPartId);
            ViewData["ExerciseFormId"] = new SelectList(_context.ExerciseForm, "Id", "ExerciseForm", workoutModel.ExerciseFormId);
            return View(workoutModel);
        }

        // GET: Workout/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutModel = await _context.Workout.FindAsync(id);
            if (workoutModel == null)
            {
                return NotFound();
            }
            ViewData["BodyPartId"] = new SelectList(_context.BodyPart, "Id", "BodyPart", workoutModel.BodyPartId);
            ViewData["ExerciseFormId"] = new SelectList(_context.ExerciseForm, "Id", "ExerciseForm", workoutModel.ExerciseFormId);
            return View(workoutModel);
        }

        // POST: Workout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkoutName,Description,Date,Completed,BodyPartId,ExerciseFormId")] WorkoutModel workoutModel)
        {
            if (id != workoutModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutModelExists(workoutModel.Id))
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
            ViewData["BodyPartId"] = new SelectList(_context.BodyPart, "Id", "BodyPart", workoutModel.BodyPartId);
            ViewData["ExerciseFormId"] = new SelectList(_context.ExerciseForm, "Id", "ExerciseForm", workoutModel.ExerciseFormId);
            return View(workoutModel);
        }

        // GET: Workout/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutModel = await _context.Workout
                .Include(w => w.BodyPart)
                .Include(w => w.ExerciseForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutModel == null)
            {
                return NotFound();
            }

            return View(workoutModel);
        }

        // POST: Workout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutModel = await _context.Workout.FindAsync(id);
            if (workoutModel != null)
            {
                _context.Workout.Remove(workoutModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutModelExists(int id)
        {
            return _context.Workout.Any(e => e.Id == id);
        }
    }
}
