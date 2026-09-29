using System;

class Student
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Marks { get; set; }

    public Student(int id, string name, int marks)
    {
        this.Name = name;
        this.Marks = marks;
        this.Id = id;
    }
}


public class HelloWorld
{
    public static void Main(string[] args)
    {
        var students = new List<Student>
        {
            new Student(101, "Jay", 80),
            new Student(102, "Rahul", 45),
            new Student(103, "Amit", 90),
            new Student(104, "Rohit", 70),
            new Student(105, "Neha", 95)
        };

        ////var result = students
        ////    .Where(stu => stu.Marks < 60)
        ////    .OrderBy(stu => stu.Name)
        ////    .Select(stu => stu.Name);

        //var result = students
        //.Where(stu => stu.Marks >= 80)
        //.Select(stu => new { stu.Name, stu.Marks });

        //var res = students.Any(stu => stu.Marks >= 90);
        //if(res == true)
        //{
        //    Console.WriteLine("Topper Exist");
        //}
        //else
        //{
        //    Console.WriteLine("Topper does not Exist");
        //}

        //foreach (var name in result)
        //{
        //    Console.WriteLine(name);
        //}


    }
}

class Student
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Marks { get; set; }

    public Student(int id, string name, int marks)
    {
        this.Name = name;
        this.Marks = marks;
        this.Id = id;
    }
}

public class HelloWorld
{
    static async Task<string> GenerateReportAsync()
    {
        await Task.Delay(2000);

        return "Report Generated Successfully";
    }

    public static async Task Main(string[] args)
    {   
        //task 1
        var students = new List<Student>
        {
            new Student(101, "Jay", 80),
            new Student(102, "Rahul", 45),
            new Student(103, "Amit", 90),
            new Student(104, "Rohit", 70),
            new Student(105, "Neha", 95)
        };

        //task 2

        var passedStudents = students.Where(stu => stu.Marks >= 60).OrderByDescending(stu => stu.Marks).Select(stu => new { stu.Name, stu.Marks });

        //task 3

        if(students.Any(stu => stu.Marks >= 90))
        {
            Console.WriteLine("Topper Exists.");
        }
        else
        {
            Console.WriteLine("No Topper.");
        }

        //task 4

        Console.WriteLine(students.Count(stu => stu.Marks >= 60));

        //task 5

        var HighestMarkStudent = students.OrderByDescending(stu => stu.Marks).FirstOrDefault();

        if (HighestMarkStudent != null)
        {
            Console.WriteLine(
                $"Highest: {HighestMarkStudent.Name} - {HighestMarkStudent.Marks}"
            );
        }

        //task 6

        Console.WriteLine("Report Generating....");

        var result = await GenerateReportAsync();

        Console.WriteLine(result);


    }
}
