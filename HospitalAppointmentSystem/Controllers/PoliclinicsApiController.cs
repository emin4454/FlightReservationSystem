using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using HospitalAppointmentSystem.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliclinicsApiController : ControllerBase
    {
        private readonly HospitalDataContext _context;

        public PoliclinicsApiController(HospitalDataContext context)
        {
            _context = context;
        }

        // GET: api/PoliclinicsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policlinic>>> Getpoliclinics()
        {
          if (_context.policlinics == null)
          {
              return NotFound();
          }
            var result = await _context.policlinics
                .Select(p => new { p.policlinicId, p.policlinicName })
                .ToListAsync();
            return Ok(result);
        }

        // GET: api/PoliclinicsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policlinic>> GetPoliclinic(int id)
        {
            if (_context.policlinics == null)
            {
                return NotFound();
            }
            var policlinic = await _context.policlinics.FindAsync(id);

            if (policlinic == null)
            {
                return NotFound();
            }
            var ret = new {policlinic.policlinicId,policlinic.policlinicName };
            return Ok(ret);
        }

        // PUT: api/PoliclinicsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoliclinic(int id, Policlinic policlinic)
        {
            if (id != policlinic.policlinicId)
            {
                return BadRequest();
            }

            _context.Entry(policlinic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliclinicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PoliclinicsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Policlinic>> PostPoliclinic([FromBody] Policlinic policlinicc)
        {
                
            var policlinic = new Policlinic { policlinicName =  "OROSPU" };
            _context.policlinics.Add(policlinic);
            await _context.SaveChangesAsync();

            return Ok(policlinic);
        }

        // DELETE: api/PoliclinicsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliclinic(int id)
        {
            if (_context.policlinics == null)
            {
                return NotFound();
            }
            var policlinic = await _context.policlinics.FindAsync(id);
            if (policlinic == null)
            {
                return NotFound();
            }

            _context.policlinics.Remove(policlinic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliclinicExists(int id)
        {
            return (_context.policlinics?.Any(e => e.policlinicId == id)).GetValueOrDefault();
        }
    }
}
