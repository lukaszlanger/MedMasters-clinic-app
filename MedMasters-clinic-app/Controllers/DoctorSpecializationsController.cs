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
    public class DoctorSpecializationsController : Controller
    {
        private readonly masterContext _context;

        public DoctorSpecializationsController(masterContext context)
        {
            _context = context;
        }

        // GET: DoctorSpecializations
        public async Task<IActionResult> Index()
        {
            var masterContext = _context.DoctorSpecializations.Include(d => d.Doctor).Include(d => d.Specialization);
            return View(await masterContext.ToListAsync());
        }

        // GET: DoctorSpecializations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecializations = await _context.DoctorSpecializations
                .Include(d => d.Doctor)
                .Include(d => d.Specialization)
                .FirstOrDefaultAsync(m => m.IdDoctorSpecialization == id);
            if (doctorSpecializations == null)
            {
                return NotFound();
            }

            return View(doctorSpecializations);
        }

        // GET: DoctorSpecializations/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker");
            ViewData["SpecializationId"] = new SelectList(_context.MedicalSpecializations, "IdSpecialization", "IdSpecialization");
            return View();
        }

        // POST: DoctorSpecializations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoctorSpecialization,DoctorId,SpecializationId")] DoctorSpecializations doctorSpecializations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorSpecializations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", doctorSpecializations.DoctorId);
            ViewData["SpecializationId"] = new SelectList(_context.MedicalSpecializations, "IdSpecialization", "IdSpecialization", doctorSpecializations.SpecializationId);
            return View(doctorSpecializations);
        }

        // GET: DoctorSpecializations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecializations = await _context.DoctorSpecializations.FindAsync(id);
            if (doctorSpecializations == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", doctorSpecializations.DoctorId);
            ViewData["SpecializationId"] = new SelectList(_context.MedicalSpecializations, "IdSpecialization", "IdSpecialization", doctorSpecializations.SpecializationId);
            return View(doctorSpecializations);
        }

        // POST: DoctorSpecializations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDoctorSpecialization,DoctorId,SpecializationId")] DoctorSpecializations doctorSpecializations)
        {
            if (id != doctorSpecializations.IdDoctorSpecialization)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorSpecializations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorSpecializationsExists(doctorSpecializations.IdDoctorSpecialization))
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
            ViewData["DoctorId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", doctorSpecializations.DoctorId);
            ViewData["SpecializationId"] = new SelectList(_context.MedicalSpecializations, "IdSpecialization", "IdSpecialization", doctorSpecializations.SpecializationId);
            return View(doctorSpecializations);
        }

        // GET: DoctorSpecializations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecializations = await _context.DoctorSpecializations
                .Include(d => d.Doctor)
                .Include(d => d.Specialization)
                .FirstOrDefaultAsync(m => m.IdDoctorSpecialization == id);
            if (doctorSpecializations == null)
            {
                return NotFound();
            }

            return View(doctorSpecializations);
        }

        // POST: DoctorSpecializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorSpecializations = await _context.DoctorSpecializations.FindAsync(id);
            _context.DoctorSpecializations.Remove(doctorSpecializations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorSpecializationsExists(int id)
        {
            return _context.DoctorSpecializations.Any(e => e.IdDoctorSpecialization == id);
        }
    }
}
