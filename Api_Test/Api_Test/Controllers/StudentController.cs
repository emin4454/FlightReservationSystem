using Api_Test.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> students = new List<Student>
        {
            new Student{studentId = 0, studentName = "Mehmet Emin", studentSurname = "Parlak" },
            new Student{studentId = 1, studentName = "Aziz", studentSurname = "Erd*gan" },
            new Student{studentId = 2, studentName = "Ahmet", studentSurname = "Zengin" },

        };
        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> Get()
        {
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var stx = students.FirstOrDefault(x => x.studentId == id);
            if (stx == null)
                return NotFound();
            return stx;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student newStudent)
        {
            students.Add(newStudent);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult<Student> Put(int id, [FromBody] Student studentApi)
        {
            var studentY = students.FirstOrDefault(z => z.studentId == id);
            if(studentY == null)
            {
                return NotFound();
            }
            else
            {
                studentY.studentId = studentApi.studentId;
                studentY.studentName = studentApi.studentName;
                studentY.studentSurname = studentApi.studentSurname;
                return studentY;
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
