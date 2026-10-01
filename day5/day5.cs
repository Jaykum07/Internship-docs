// Online C# compiler (editor) for free
// Write and run C# online using this editor.

using System;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}

class StudentService
{   
    public string GetStudent()
    {
        Console.WriteLine("Getting Student..");
        return "";
    }
}

class StudentManager
{   private StudentService Service;
 
     public StudentManager(StudentService service){
         this.Service = service;
     }
 
    public void Get()
    {
    Service.GetStudent();
    }
}

public class HelloWorld {
    public static void Main(string[] args) {
        StudentService studentService = new StudentService();
        StudentManager studentManage = new StudentManager(studentService);
        studentManage.Get();
    }
}