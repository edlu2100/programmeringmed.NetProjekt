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
        public async Task<IActionResult> Dashboard()
        {
            var username = User.Identity.Name;

            // Beräkna gränsvärdet för 30 dagar tillbaka i tiden
            var thirtyDaysAgo = DateTime.Today.AddDays(-30);

            // Hämta antal avslutade träningspass för varje typ av träning under de senaste 30 dagarna
            var gymCount = await _context.Workout
                .Where(w => w.Username == username && w.ExerciseFormId == 2 && w.Completed == true && w.Date >= thirtyDaysAgo)
                .CountAsync();

            var conditionCount = await _context.Workout
                .Where(w => w.Username == username && w.ExerciseFormId == 1 && w.Completed == true && w.Date >= thirtyDaysAgo)
                .CountAsync();

            var skiingCount = await _context.Workout
                .Where(w => w.Username == username && w.ExerciseFormId == 3 && w.Completed == true && w.Date >= thirtyDaysAgo)
                .CountAsync();

            // Skapa en lista med träningsdata
            var workoutData = new List<int> { gymCount, conditionCount, skiingCount };

            // Skicka datan till vyn
            return View(workoutData);
        }






            public async Task<IActionResult> RenderBarChart()
            {
                var username = User.Identity.Name;

                // Beräkna gränsvärdet för 30 dagar tillbaka i tiden
                var thirtyDaysAgo = DateTime.Today.AddDays(-30);

                // Hämta antal träningspass per dag de senaste 30 dagarna
                var workoutCountsPerDay = new List<int>();

                for (int i = 0; i < 30; i++)
                {
                    var currentDate = DateTime.Today.AddDays(-i);
                    var workoutCount = await _context.Workout
                        .Where(w => w.Username == username && w.Completed == true && w.Date.HasValue && w.Date.Value.Date == currentDate.Date)
                        .CountAsync();

                    workoutCountsPerDay.Insert(0, workoutCount); // Lägg till antalet träningspass för den aktuella dagen
                }

                // Skapa en lista med datumsträngar för stapeldiagrammet
                var workoutDates = Enumerable.Range(0, 30)
                    .Select(i => DateTime.Today.AddDays(-i).ToShortDateString())
                    .ToList();

                return PartialView("_BarChartPartial", new Tuple<List<int>, List<string>>(workoutCountsPerDay, workoutDates));
            }

        // GET: Workout/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutModel = await _context.Workout
                .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise) // inkludera övningarna
                .FirstOrDefaultAsync(m => m.Id == id);

            if (workoutModel == null)
            {
                return NotFound();
            }

            // Konditionsträning
            if (workoutModel.ExerciseFormId == 1)
            {
                workoutModel = await _context.Workout
                    .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise) // inkludera övningarna
                    .Include(w => w.Condition) // inkludera kondition
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            // Gymträning
            else if (workoutModel.ExerciseFormId == 2)
            {
                workoutModel = await _context.Workout
                    .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise) // inkludera övningarna
                    .Include(w => w.BodyPart) // inkludera kroppsdel
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            // Skidåkningsträning
            else if (workoutModel.ExerciseFormId == 3)
            {

                workoutModel = await _context.Workout
                    .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise) // inkludera övningarna
                    .Include(w => w.Skiing) // inkludera skidåkning
                    .Include(w => w.Skiing.Method) // inkludera metod
                    .Include(w => w.Skiing.Focus) // inkludera fokus
                    .Include(w => w.Skiing.Discipline) // inkludera disciplin
                    .Include(w => w.Skiing.Organization) // inkludera organisation
                    .FirstOrDefaultAsync(m => m.Id == id);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Date,BodyPartId,ExerciseFormId,Length,Rating,Comment")] WorkoutModel workoutModel)
        {
            if (ModelState.IsValid)
            {
                // Bestäm om träningspasset är slutfört baserat på datum
                workoutModel.Completed = DateTime.Today > workoutModel.Date;


                if (workoutModel.ExerciseFormId == 1) // Om "Kondition" är valt
                {
                    workoutModel.BodyPartId = null; // Sätt BodyPartId till null
                    workoutModel.SkiingId = null; // Sätt BodyPartId till null
                }
                else if (workoutModel.ExerciseFormId == 2)//Om gym är valt
                {
                    workoutModel.SkiingId = null; // Sätt BodyPartId till null
                }
                else if (workoutModel.ExerciseFormId == 3) // Om "Skiing" är valt
                {
                    workoutModel.Completed = true;
                    workoutModel.BodyPartId = null; // Sätt BodyPartId till null
                }

                // Hämta användarnamnet från identitetsautentiseringen
                workoutModel.Username = User.Identity?.Name;

                _context.Add(workoutModel);
                await _context.SaveChangesAsync();

                // Omdirigera beroende på vilken typ av träning som valdes
                if (workoutModel.ExerciseFormId == 1) // Om "Kondition" är valt
                {
                    return RedirectToAction("Create", "Condition", new { workoutId = workoutModel.Id }); // Redirect till index för Workout
                }
                else if (workoutModel.ExerciseFormId == 2) // Om "Gym" är valt
                {
                    // Redirect till WorkoutExercise/Create och inkludera id för det skapade träningspasset
                    return RedirectToAction("Create", "WorkoutExercise", new { workoutId = workoutModel.Id });
                }
                else if (workoutModel.ExerciseFormId == 3) // Om "Skiing" är valt
                {
                    // Redirect till SkiingModel/Create och inkludera id för det skapade träningspasset
                    return RedirectToAction("Create", "Skiing", new { workoutId = workoutModel.Id });
                }
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
        // POST: Workout/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Date,Completed,Comment,Rating,Length,Username,BodyPartId,ExerciseFormId,SkiingId, ConditionId")] WorkoutModel workoutModel)
        {
            if (id != workoutModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Hämta användarnamnet från autentiseringen
                    workoutModel.Username = User.Identity?.Name;

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

                // Redirect the user based on ExerciseFormId
                if (workoutModel.ExerciseFormId == 2) // Gym
                {
                    // Check if ExerciseForm is gym
                    return RedirectToAction("ListByWorkoutId", "WorkoutExercise", new { workoutId = workoutModel.Id });
                }
                else
                {
                    return RedirectToAction("Index", "Workout");
                }
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
        // POST: Workout/MarkCompletedWithLength
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkCompletedWithLength(int workoutId, int length, int rating, string comment)
        {
            var workout = await _context.Workout.FindAsync(workoutId);

            if (workout != null)
            {
                workout.Completed = true;
                workout.Length = length; // Uppdatera längden
                workout.Rating = rating; // Sätt ratingen
                workout.Comment = comment; // Sätt kommentaren
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Workout");
        }

    }
}
