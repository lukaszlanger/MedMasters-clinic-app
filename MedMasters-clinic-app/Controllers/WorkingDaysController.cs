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
    public class WorkingDaysController : Controller
    {
        private readonly masterContext _context;

        public WorkingDaysController(masterContext context)
        {
            _context = context;
        }

        // GET: WorkingDays
        public async Task<IActionResult> Index()
        {
            var masterContext = _context.WorkingDays.Include(w => w.Worker);
            return View(await masterContext.ToListAsync());
        }

        // GET: WorkingDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingDays = await _context.WorkingDays
                .Include(w => w.Worker)
                .FirstOrDefaultAsync(m => m.IdWorkingDay == id);
            if (workingDays == null)
            {
                return NotFound();
            }

            return View(workingDays);
        }

        // GET: WorkingDays/Create
        public IActionResult Create()
        {
            ViewData["WorkerId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker");
            return View();
        }

        // POST: WorkingDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWorkingDay,TimeStart,TimeEnd,WorkerId")] WorkingDays workingDays)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingDays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkerId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", workingDays.WorkerId);
            return View(workingDays);
        }

        // GET: WorkingDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingDays = await _context.WorkingDays.FindAsync(id);
            if (workingDays == null)
            {
                return NotFound();
            }
            ViewData["WorkerId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", workingDays.WorkerId);
            return View(workingDays);
        }

        // POST: WorkingDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWorkingDay,TimeStart,TimeEnd,WorkerId")] WorkingDays workingDays)
        {
            if (id != workingDays.IdWorkingDay)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingDays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingDaysExists(workingDays.IdWorkingDay))
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
            ViewData["WorkerId"] = new SelectList(_context.Workers, "IdWorker", "IdWorker", workingDays.WorkerId);
            return View(workingDays);
        }

        // GET: WorkingDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingDays = await _context.WorkingDays
                .Include(w => w.Worker)
                .FirstOrDefaultAsync(m => m.IdWorkingDay == id);
            if (workingDays == null)
            {
                return NotFound();
            }

            return View(workingDays);
        }

        // POST: WorkingDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workingDays = await _context.WorkingDays.FindAsync(id);
            _context.WorkingDays.Remove(workingDays);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingDaysExists(int id)
        {
            return _context.WorkingDays.Any(e => e.IdWorkingDay == id);
        }
    }
}
