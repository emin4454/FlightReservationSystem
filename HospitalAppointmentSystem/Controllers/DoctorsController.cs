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
    public class DoctorsController : Controller
    {
        private readonly HospitalDataContext _context;

        public DoctorsController(HospitalDataContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            var filteredDoctors = _context.doctors.Include(i => i.branch).ToList();
            return _context.doctors != null ? 
                          View(await _context.doctors.ToListAsync()) :
                          Problem("Entity set 'HospitalDataContext.doctors'  is null.");
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.doctors == null)
            {
                return NotFound();
            }

            var filteredDoctors = _context.doctors.Include(i => i.branch);
            var doctor = await filteredDoctors.FirstAsync(i => id == i.doctorId);
            if (doctor == null)
            {
                return NotFound();
            }
             
            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewBag.Branches = _context.branches.Select(i => new SelectListItem
            {
                Text = i.branchName,
                Value = i.branchId.ToString(),
            });
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("doctorName,branchId")] DoctorView doctorView)
        {
            if (ModelState.IsValid)
            {
                var branchForDoctor = _context.branches.FirstOrDefault(i => i.branchId == doctorView.branchId);
                Doctor doctor = new Doctor
                {
                    doctorName = doctorView.doctorName,
                    branch = branchForDoctor,
                };
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.doctors == null)
            {
                return NotFound();

            }
            var filteredDoctors = _context.doctors.Include(i => i.branch);
            var doctor = await filteredDoctors.FirstAsync(i => id == i.doctorId);

            if (doctor == null)
            {
                return NotFound();
            }
            var doctorView = new DoctorView
            {
                doctorId = doctor.doctorId,
                doctorName = doctor.doctorName,
                branchId = doctor.branch.branchId
            };
            ViewBag.Branches = _context.branches.Select(i => new SelectListItem
            {
                Text = i.branchName,
                Value = i.branchId.ToString(),
                Selected = i.branchId == doctor.branch.branchId
            });
            return View(doctorView);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("doctorId,doctorName,branchId")] DoctorView doctorView)
        {
            Branch branchForDoctor = _context.branches.FirstOrDefault(i => i.branchId == doctorView.branchId);
            var doctor = new Doctor
            {
                doctorId = id,
                doctorName = doctorView.doctorName,
                branch = branchForDoctor
            };
            if (id != doctor.doctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.doctorId))
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
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.doctors
                .FirstOrDefaultAsync(m => m.doctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.doctors == null)
            {
                return Problem("Entity set 'HospitalDataContext.doctors'  is null.");
            }
            var doctor = await _context.doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.doctors.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
          return (_context.doctors?.Any(e => e.doctorId == id)).GetValueOrDefault();
        }
    }
}
