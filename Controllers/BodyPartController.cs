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
    public class BodyPartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BodyPartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BodyPart
        public async Task<IActionResult> Index()
        {
            return View(await _context.BodyPart.ToListAsync());
        }

        // GET: BodyPart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyPartModel = await _context.BodyPart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyPartModel == null)
            {
                return NotFound();
            }

            return View(bodyPartModel);
        }

        // GET: BodyPart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyPart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BodyPart")] BodyPartModel bodyPartModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodyPartModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodyPartModel);
        }

        // GET: BodyPart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyPartModel = await _context.BodyPart.FindAsync(id);
            if (bodyPartModel == null)
            {
                return NotFound();
            }
            return View(bodyPartModel);
        }

        // POST: BodyPart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BodyPart")] BodyPartModel bodyPartModel)
        {
            if (id != bodyPartModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyPartModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyPartModelExists(bodyPartModel.Id))
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
            return View(bodyPartModel);
        }

        // GET: BodyPart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyPartModel = await _context.BodyPart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyPartModel == null)
            {
                return NotFound();
            }

            return View(bodyPartModel);
        }

        // POST: BodyPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodyPartModel = await _context.BodyPart.FindAsync(id);
            if (bodyPartModel != null)
            {
                _context.BodyPart.Remove(bodyPartModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyPartModelExists(int id)
        {
            return _context.BodyPart.Any(e => e.Id == id);
        }
    }
}
