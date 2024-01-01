using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using HospitalAppointmentSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAppointmentSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HospitalDataContext _context;

        public AppointmentsController(HospitalDataContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
              return _context.appointments != null ? 
                          View(await _context.appointments.ToListAsync()) :
                          Problem("Entity set 'HospitalDataContext.appointments'  is null.");
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointments
                .FirstOrDefaultAsync(m => m.appointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            //ViewBag.DoctorList = new SelectList(_context.doctors, "DoctorId", "Name");
            ViewBag.Doctors = _context.doctors.Select(i => new SelectListItem
            {
                Text = i.doctorName,
                Value = i.doctorId.ToString(),
            });
            //ViewBag.UserList = new SelectList(_context.Users, "UserId", "Name");
            ViewBag.Users = _context.Users.Select(i => new SelectListItem
            {
                Text = i.UserName,
                Value = i.Id.ToString(),
            });
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("appointmentId,appointmentDate,appointmentTime")] Appointment appointment, int doctorId, int userId)
        {
            if (ModelState.IsValid) 
            {
                appointment.doctor = await _context.doctors.FindAsync(doctorId);
                appointment.user = await _context.Users.FindAsync(userId);
                _context.appointments.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("appointmentId,appointmentDate,appointmentTime")] Appointment appointment)
        {
            if (id != appointment.appointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.appointmentId))
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
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointments
                .FirstOrDefaultAsync(m => m.appointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.appointments == null)
            {
                return Problem("Entity set 'HospitalDataContext.appointments'  is null.");
            }
            var appointment = await _context.appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.appointments.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> testView()
        {
            return View();
        }
        private bool AppointmentExists(int id)
        {
          return (_context.appointments?.Any(e => e.appointmentId == id)).GetValueOrDefault();
        }
    }
}
