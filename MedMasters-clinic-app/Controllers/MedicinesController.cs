using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klinika.Models;

namespace Klinika.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly masterContext _context;

        public MedicinesController(masterContext context)
        {
            _context = context;
        }

        // GET: Medicines
        public async Task<IActionResult> Index()
        {
            var masterContext = _context.Medicines.Include(m => m.Visit);
            return View(await masterContext.ToListAsync());
        }

        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicines = await _context.Medicines
                .Include(m => m.Visit)
                .FirstOrDefaultAsync(m => m.IdMedicine == id);
            if (medicines == null)
            {
                return NotFound();
            }

            return View(medicines);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            ViewData["VisitId"] = new SelectList(_context.Visits, "IdVisit", "IdVisit");
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedicine,MedicineName,Dosage,DateOfIssue,ExpirationDay,VisitId")] Medicines medicines)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VisitId"] = new SelectList(_context.Visits, "IdVisit", "IdVisit", medicines.VisitId);
            return View(medicines);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicines = await _context.Medicines.FindAsync(id);
            if (medicines == null)
            {
                return NotFound();
            }
            ViewData["VisitId"] = new SelectList(_context.Visits, "IdVisit", "IdVisit", medicines.VisitId);
            return View(medicines);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedicine,MedicineName,Dosage,DateOfIssue,ExpirationDay,VisitId")] Medicines medicines)
        {
            if (id != medicines.IdMedicine)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicinesExists(medicines.IdMedicine))
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
            ViewData["VisitId"] = new SelectList(_context.Visits, "IdVisit", "IdVisit", medicines.VisitId);
            return View(medicines);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicines = await _context.Medicines
                .Include(m => m.Visit)
                .FirstOrDefaultAsync(m => m.IdMedicine == id);
            if (medicines == null)
            {
                return NotFound();
            }

            return View(medicines);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicines = await _context.Medicines.FindAsync(id);
            _context.Medicines.Remove(medicines);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicinesExists(int id)
        {
            return _context.Medicines.Any(e => e.IdMedicine == id);
        }
    }
}
