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
    public class MethodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MethodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Method
        public async Task<IActionResult> Index()
        {
            return View(await _context.Method.ToListAsync());
        }

        // GET: Method/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodModel = await _context.Method
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodModel == null)
            {
                return NotFound();
            }

            return View(methodModel);
        }

        // GET: Method/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Method/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MethodName")] MethodModel methodModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(methodModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(methodModel);
        }

        // GET: Method/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodModel = await _context.Method.FindAsync(id);
            if (methodModel == null)
            {
                return NotFound();
            }
            return View(methodModel);
        }

        // POST: Method/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MethodName")] MethodModel methodModel)
        {
            if (id != methodModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(methodModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodModelExists(methodModel.Id))
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
            return View(methodModel);
        }

        // GET: Method/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodModel = await _context.Method
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodModel == null)
            {
                return NotFound();
            }

            return View(methodModel);
        }

        // POST: Method/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var methodModel = await _context.Method.FindAsync(id);
            if (methodModel != null)
            {
                _context.Method.Remove(methodModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodModelExists(int id)
        {
            return _context.Method.Any(e => e.Id == id);
        }
    }
}
