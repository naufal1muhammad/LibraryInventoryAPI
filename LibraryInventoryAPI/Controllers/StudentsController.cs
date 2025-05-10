using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryInventoryAPI.Data;
using LibraryInventoryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public StudentsController(LibraryContext context)
        {
            _context = context;
        }

        // POST: api/students
        [HttpPost]
        public ActionResult<Student> RegisterStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound("Student not found.");
            return student;
        }
    }
}
