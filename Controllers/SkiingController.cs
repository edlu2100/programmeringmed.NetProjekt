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
    public class SkiingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkiingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Skiing
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Skiing.Include(s => s.Discipline).Include(s => s.Focus).Include(s => s.Method).Include(s => s.Organization).Include(s => s.Workout);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Skiing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiingModel = await _context.Skiing
                .Include(s => s.Discipline)
                .Include(s => s.Focus)
                .Include(s => s.Method)
                .Include(s => s.Organization)
                .Include(s => s.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skiingModel == null)
            {
                return NotFound();
            }

            return View(skiingModel);
        }

        // GET: Skiing/Create
        public IActionResult Create(int workoutId)
        {
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "DisciplineName");
            ViewData["FocusId"] = new SelectList(_context.SkiingFocus, "Id", "FocusName");
            ViewData["MethodId"] = new SelectList(_context.Method, "Id", "MethodName");
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "OrganizationName");
            ViewData["WorkoutId"] = workoutId;
            return View();
        }

        // POST: Skiing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.[HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int workoutId, [Bind("Id,Location,OrganizationId,MethodId,DisciplineId,FocusId,TurnsPerRun,GateDistance,Freeruns,Runs,CompletedRuns,ApproachToTask,Goal")] SkiingModel skiingModel)
        {
            if (ModelState.IsValid)
            {
                // Tilldela workoutId från parametern till SkiingModel
                skiingModel.WorkoutId = workoutId;

                // Lägg till SkiingModel i databasen
                _context.Add(skiingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Workout"); // Redirect till index för Workout
            }
            // Om ModelState inte är giltigt, returnera samma vy med felmeddelanden
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "DisciplineName", skiingModel.DisciplineId);
            ViewData["FocusId"] = new SelectList(_context.SkiingFocus, "Id", "FocusName", skiingModel.FocusId);
            ViewData["MethodId"] = new SelectList(_context.Method, "Id", "MethodName", skiingModel.MethodId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description", skiingModel.WorkoutId);
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "OrganizationName", skiingModel.OrganizationId);
            return View(skiingModel);
        }

        // GET: Skiing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiingModel = await _context.Skiing.FindAsync(id);
            if (skiingModel == null)
            {
                return NotFound();
            }
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "DisciplineName", skiingModel.DisciplineId);
            ViewData["FocusId"] = new SelectList(_context.SkiingFocus, "Id", "FocusName", skiingModel.FocusId);
            ViewData["MethodId"] = new SelectList(_context.Method, "Id", "MethodName", skiingModel.MethodId);
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "OrganizationName", skiingModel.OrganizationId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description", skiingModel.WorkoutId);
            return View(skiingModel);
        }

        // POST: Skiing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Location,OrganizationId,DisciplineId,MethodId,FocusId,TurnsPerRun,GateDistance,Freeruns,Runs,CompletedRuns,ApproachToTask,Goal,WorkoutId")] SkiingModel skiingModel)
        {
            if (id != skiingModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skiingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkiingModelExists(skiingModel.Id))
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
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "DisciplineName", skiingModel.DisciplineId);
            ViewData["FocusId"] = new SelectList(_context.SkiingFocus, "Id", "FocusName", skiingModel.FocusId);
            ViewData["MethodId"] = new SelectList(_context.Method, "Id", "MethodName", skiingModel.MethodId);
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "OrganizationName", skiingModel.OrganizationId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Description", skiingModel.WorkoutId);
            return View(skiingModel);
        }

        // GET: Skiing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiingModel = await _context.Skiing
                .Include(s => s.Discipline)
                .Include(s => s.Focus)
                .Include(s => s.Method)
                .Include(s => s.Organization)
                .Include(s => s.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skiingModel == null)
            {
                return NotFound();
            }

            return View(skiingModel);
        }

        // POST: Skiing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skiingModel = await _context.Skiing.FindAsync(id);
            if (skiingModel != null)
            {
                _context.Skiing.Remove(skiingModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkiingModelExists(int id)
        {
            return _context.Skiing.Any(e => e.Id == id);
        }
    }
}
