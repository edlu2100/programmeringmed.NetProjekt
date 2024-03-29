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
    public class OrganizationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organization
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organization.ToListAsync());
        }

        // GET: Organization/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationModel = await _context.Organization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationModel == null)
            {
                return NotFound();
            }

            return View(organizationModel);
        }

        // GET: Organization/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrganizationName")] OrganizationModel organizationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizationModel);
        }

        // GET: Organization/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationModel = await _context.Organization.FindAsync(id);
            if (organizationModel == null)
            {
                return NotFound();
            }
            return View(organizationModel);
        }

        // POST: Organization/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrganizationName")] OrganizationModel organizationModel)
        {
            if (id != organizationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationModelExists(organizationModel.Id))
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
            return View(organizationModel);
        }

        // GET: Organization/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationModel = await _context.Organization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationModel == null)
            {
                return NotFound();
            }

            return View(organizationModel);
        }

        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationModel = await _context.Organization.FindAsync(id);
            if (organizationModel != null)
            {
                _context.Organization.Remove(organizationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationModelExists(int id)
        {
            return _context.Organization.Any(e => e.Id == id);
        }
    }
}
