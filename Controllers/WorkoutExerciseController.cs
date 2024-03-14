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
            ViewData["WorkoutId"] = workoutId; // Tilldela WorkoutId till ViewData
            return View();
        }

        // POST: WorkoutExercise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int workoutId, [Bind("Id,ExerciseId")] WorkoutExerciseModel workoutExerciseModel)
        {
            if (ModelState.IsValid)
            {
                workoutExerciseModel.WorkoutId = workoutId; // Tilldela workoutId från parameter till workoutExerciseModel

                _context.Add(workoutExerciseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Workout", new { id = workoutId }); // Redirect till detaljsidan för Workout
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "ExerciseName", workoutExerciseModel.ExerciseId);
            ViewData["WorkoutId"] = workoutId; // Tilldela WorkoutId till ViewData
            return View(workoutExerciseModel);
        }

        
        // GET: WorkoutExercise/CreateNew
        public IActionResult CreateNew(int workoutId)
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "ExerciseName");
            ViewData["WorkoutId"] = workoutId; // Tilldela WorkoutId till ViewData
            return View();
        }

        // POST: WorkoutExercise/CreateNew
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(int workoutId, [Bind("Id,ExerciseId")] WorkoutExerciseModel workoutExerciseModel)
        {
            if (ModelState.IsValid)
            {
                workoutExerciseModel.WorkoutId = workoutId; // Tilldela workoutId från parameter till workoutExerciseModel

                _context.Add(workoutExerciseModel);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListByWorkoutId", "WorkoutExercise", new { workoutId = workoutId });
            }

            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "ExerciseName", workoutExerciseModel.ExerciseId);
            ViewData["WorkoutId"] = workoutId; // Tilldela WorkoutId till ViewData
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
                await _context.SaveChangesAsync();
            }

            // Redirect till ListByWorkoutId med det specifika workoutId
            return RedirectToAction("ListByWorkoutId", "WorkoutExercise", new { workoutId = workoutExerciseModel.WorkoutId });
        }


        private bool WorkoutExerciseModelExists(int id)
        {
            return _context.WorkoutExercise.Any(e => e.Id == id);
        }
            // GET: WorkoutExercise/ListByWorkoutId/5
        public async Task<IActionResult> ListByWorkoutId(int? workoutId)
        {
            if (workoutId == null)
            {
                return NotFound();
            }

            var workoutExercises = await _context.WorkoutExercise
                .Include(we => we.Exercise)
                .Where(we => we.WorkoutId == workoutId)
                .ToListAsync();

            if (workoutExercises == null || workoutExercises.Count == 0)
            {
                return NotFound();
            }
            
            ViewBag.WorkoutId = workoutId; // Lägg till workoutId i ViewBag


            return View(workoutExercises);
        }
        // Metod för att omdirigera till Create med workoutId som parameter
        public IActionResult RedirectToCreate(int workoutId)
        {
            return RedirectToAction("CreateNew", new { workoutId = workoutId });
        }

        
        


    }
}
