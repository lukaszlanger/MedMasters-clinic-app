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
    public class VisitsController : Controller
    {
        private readonly masterContext _context;

        public VisitsController(masterContext context)
        {
            _context = context;
        }

        // GET: Visits
        public async Task<IActionResult> Index()
        {
            var masterContext = _context.Visits.Include(v => v.Doctor).Include(v => v.Patient);
            return View(await masterContext.ToListAsync());
        }

        // GET: Visits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visits = await _context.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(m => m.IdVisit == id);
            if (visits == null)
            {
                return NotFound();
            }

            return View(visits);
        }

        // GET: Visits/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Pesel", "Pesel");
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVisit,VisitsDescription,Date,Compleated,PatientId,DoctorId")] Visits visits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", visits.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Pesel", "Pesel", visits.PatientId);
            return View(visits);
        }

        // GET: Visits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visits = await _context.Visits.FindAsync(id);
            if (visits == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", visits.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Pesel", "Pesel", visits.PatientId);
            return View(visits);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVisit,VisitsDescription,Date,Compleated,PatientId,DoctorId")] Visits visits)
        {
            if (id != visits.IdVisit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitsExists(visits.IdVisit))
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
            ViewData["DoctorId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", visits.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Pesel", "Pesel", visits.PatientId);
            return View(visits);
        }

        // GET: Visits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visits = await _context.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(m => m.IdVisit == id);
            if (visits == null)
            {
                return NotFound();
            }

            return View(visits);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visits = await _context.Visits.FindAsync(id);
            _context.Visits.Remove(visits);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitsExists(int id)
        {
            return _context.Visits.Any(e => e.IdVisit == id);
        }
    }
}
