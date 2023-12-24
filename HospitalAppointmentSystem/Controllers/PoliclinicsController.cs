using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.ViewModels;

namespace HospitalAppointmentSystem.Controllers
{
    public class PoliclinicsController : Controller
    {
        private readonly HospitalDataContext _context;

        public PoliclinicsController(HospitalDataContext context)
        {
            _context = context;
        }

        // GET: Policlinics
        public async Task<IActionResult> Index()
        {
              return _context.policlinics != null ? 
                          View(await _context.policlinics.ToListAsync()) :
                          Problem("Entity set 'HospitalDataContext.policlinics'  is null.");
        }

        // GET: Policlinics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.policlinics == null)
            {
                return NotFound();
            }

            var policlinic = await _context.policlinics
                .FirstOrDefaultAsync(m => m.policlinicId == id);
            if (policlinic == null)
            {
                return NotFound();
            }

            return View(policlinic);
        }

        // GET: Policlinics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Policlinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("policlinicName")] PoliclinicView policlinicView)
        {
            if (ModelState.IsValid)
            {
                Policlinic policlinic = new Policlinic { policlinicName = policlinicView.policlinicName };
                _context.Add(policlinic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Policlinics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.policlinics == null)
            {
                return NotFound();
            }

            var policlinic = await _context.policlinics.FindAsync(id);
            if (policlinic == null)
            {
                return NotFound();
            }
            return View(policlinic);
        }

        // POST: Policlinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("policlinicId,policlinicName")] Policlinic policlinic)
        {
            if (id != policlinic.policlinicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policlinic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliclinicExists(policlinic.policlinicId))
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
            return View(policlinic);
        }

        // GET: Policlinics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.policlinics == null)
            {
                return NotFound();
            }

            var policlinic = await _context.policlinics
                .FirstOrDefaultAsync(m => m.policlinicId == id);
            if (policlinic == null)
            {
                return NotFound();
            }

            return View(policlinic);
        }

        // POST: Policlinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.policlinics == null)
            {
                return Problem("Entity set 'HospitalDataContext.policlinics'  is null.");
            }
            var policlinic = await _context.policlinics.FindAsync(id);
            if (policlinic != null)
            {
                _context.policlinics.Remove(policlinic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliclinicExists(int id)
        {
          return (_context.policlinics?.Any(e => e.policlinicId == id)).GetValueOrDefault();
        }
    }
}
