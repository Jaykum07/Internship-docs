using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Marks = 85 },
            new Student { Id = 2, Name = "Jane Smith", Marks = 92 },
            new Student { Id = 3, Name = "Alice Johnson", Marks = 78 }
        };

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {

                return Ok(students);

            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult addStudent(Student student)   
        {
            Student stu = new Student
            {
                Id = students.Count() + 1,
                Name = student.Name,
                Marks = student.Marks
            };

            students.Add(stu);

            return CreatedAtAction(nameof(GetStudentById), new { id = stu.Id }, stu);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Student student)
        {
            var stu = students.FirstOrDefault(stud => stud.Id == id);

            if (stu == null) return NotFound();
            else
            {
                stu.Name = student.Name;
                stu.Marks = student.Marks;
                return Ok(stu);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var stu = students.FirstOrDefault(stud => stud.Id == id);

            if (stu == null) return NotFound();
            
             students.Remove(stu);
             return Ok("Student Deleted Successfully");
        }

    }
}
