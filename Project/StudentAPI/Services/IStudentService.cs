using StudentAPI.Models;
namespace StudentAPI.Services
{
    public interface IStudentService
    {   
        List<Student> GetStudents();
        Student GetStudentByID(int id);
    }
}
