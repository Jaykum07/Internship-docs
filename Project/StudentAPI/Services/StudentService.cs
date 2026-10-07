using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc; 

using StudentAPI.Models;
namespace StudentAPI.Services

{
    public class StudentService: IStudentService
    {
        private List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Marks = 85 },
            new Student { Id = 2, Name = "Jane Smith", Marks = 92 },
            new Student { Id = 3, Name = "Alice Johnson", Marks = 78 }
        };

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student? GetStudentById(int id)
        {
            var stu = students.FirstOrDefault(stu => stu.Id == id);

            return stu;

        }
    }
}
