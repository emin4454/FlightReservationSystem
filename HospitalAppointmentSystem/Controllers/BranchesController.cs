﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HospitalAppointmentSystem.Controllers
{
    public class BranchesController : Controller
    {
        private readonly HospitalDataContext _context;

        public BranchesController(HospitalDataContext context)
        {
            _context = context;
        }

        // GET: Branches
        public async Task<IActionResult> Index()
        {
            var filteredBranches = _context.branches.Include(i=>i.policlinic).ToList();
          return _context.branches != null ? 
                          View(await _context.branches.ToListAsync()) :
                          Problem("Entity set 'HospitalDataContext.branches'  is null.");
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.branches == null)
            {
                return NotFound();
            }

            var branch = await _context.branches
                .FirstOrDefaultAsync(m => m.branchId == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            ViewBag.Policlinics = _context.policlinics.Select(i => new SelectListItem
            {
                Text = i.policlinicName,
                Value = i.policlinicId.ToString(),
            });
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("branchName,policlinicId")] BranchView branchView)
        {
            if (ModelState.IsValid)
            {
                Policlinic policlinicForBranch = _context.policlinics.FirstOrDefault(i => i.policlinicId == branchView.policlinicId);
                Branch branch = new Branch
                {
                    branchName = branchView.branchName,
                    policlinic = policlinicForBranch
                };
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.branches == null)
            {
                return NotFound();
            }

            var branch = await _context.branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("branchId,branchName")] Branch branch)
        {
            if (id != branch.branchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branch.branchId))
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
            return View(branch);
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.branches == null)
            {
                return NotFound();
            }

            var branch = await _context.branches
                .FirstOrDefaultAsync(m => m.branchId == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.branches == null)
            {
                return Problem("Entity set 'HospitalDataContext.branches'  is null.");
            }
            var branch = await _context.branches.FindAsync(id);
            if (branch != null)
            {
                _context.branches.Remove(branch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(int id)
        {
          return (_context.branches?.Any(e => e.branchId == id)).GetValueOrDefault();
        }
    }
}
