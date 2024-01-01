using Hospital.Data;
using Microsoft.AspNetCore.Mvc;
using HospitalAppointmentSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly HospitalDataContext _context;
        public ApiController(HospitalDataContext context)
        {
            _context = context;
        }

        // GET: api/<ApiController>
        [HttpGet]
        public List<Policlinic> Get()
        {
            return _context.policlinics.ToList();
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public Policlinic Get(int id)
        {
            var y = _context.policlinics.FirstOrDefault(x => x.policlinicId == id);
            return y;
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] Policlinic value)
        {
            _context.policlinics.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Policlinic value)
        {
            var y1 = _context.policlinics.FirstOrDefault(x => x.policlinicId == id);
            if(y1 == null)
            {
                return NotFound();
            }
            else
            {
                y1.policlinicName = value.policlinicName;
                _context.Update(y1);
                _context.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var y1 = _context.policlinics.FirstOrDefault(s => s.policlinicId == id);
            if(y1 is null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(y1);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
