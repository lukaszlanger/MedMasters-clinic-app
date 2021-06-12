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
    public class MedicalSpecializationsController : Controller
    {
        private readonly masterContext _context;

        public MedicalSpecializationsController(masterContext context)
        {
            _context = context;
        }

        // GET: MedicalSpecializations
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalSpecializations.ToListAsync());
        }

        // GET: MedicalSpecializations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalSpecializations = await _context.MedicalSpecializations
                .FirstOrDefaultAsync(m => m.IdSpecialization == id);
            if (medicalSpecializations == null)
            {
                return NotFound();
            }

            return View(medicalSpecializations);
        }

        // GET: MedicalSpecializations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalSpecializations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSpecialization,SpecializationName")] MedicalSpecializations medicalSpecializations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalSpecializations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalSpecializations);
        }

        // GET: MedicalSpecializations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalSpecializations = await _context.MedicalSpecializations.FindAsync(id);
            if (medicalSpecializations == null)
            {
                return NotFound();
            }
            return View(medicalSpecializations);
        }

        // POST: MedicalSpecializations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSpecialization,SpecializationName")] MedicalSpecializations medicalSpecializations)
        {
            if (id != medicalSpecializations.IdSpecialization)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalSpecializations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalSpecializationsExists(medicalSpecializations.IdSpecialization))
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
            return View(medicalSpecializations);
        }

        // GET: MedicalSpecializations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalSpecializations = await _context.MedicalSpecializations
                .FirstOrDefaultAsync(m => m.IdSpecialization == id);
            if (medicalSpecializations == null)
            {
                return NotFound();
            }

            return View(medicalSpecializations);
        }

        // POST: MedicalSpecializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalSpecializations = await _context.MedicalSpecializations.FindAsync(id);
            _context.MedicalSpecializations.Remove(medicalSpecializations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalSpecializationsExists(int id)
        {
            return _context.MedicalSpecializations.Any(e => e.IdSpecialization == id);
        }
    }
}
