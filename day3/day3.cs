// using System;
// using System.Collections.Generic;

// class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public int Marks { get; set; }

//     public Student(int id, string name, int marks)
//     {
//         this.Id = id;
//         this.Name = name;
//         this.Marks = marks;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Student> students = new List<Student>();
//         students.Add(new Student(101, "Jagrati", 80));
//         students.Add(new Student(102, "Janvi", 95));
//         students.Add(new Student(103, "Jay", 73));
//         students.Add(new Student(104, "Jay K", 90));
//         students.Add(new Student(105, "Jay V", 40));

//         //task 1: Display all students

//         foreach (var stu in students)
//         {
//             Console.WriteLine($"Name: {stu.Name}, Id: {stu.Id} and Marks: {stu.Marks}");
//         }

//         //task 2: find who passed >=60

//         List<Student> passedStudents = students.FindAll(student => student.Marks >= 60);

//         foreach (var stu in passedStudents)
//         {
//             Console.WriteLine($"Name: {stu.Name}, Id: {stu.Id}");
//         }

//         //task 3: find first topper

//         Student topper = students.Find(student => student.Marks >= 90);

//         Console.WriteLine($"Topper: {topper.Name}");

//         //task 4: create dictionary

//         Dictionary<int, Student> studentDist = new Dictionary<int, Student>();
//         foreach (var stu in students)
//         {
//             studentDist[stu.Id] = stu;
//         }

//         var stuWithId = studentDist[103];

//         Console.WriteLine($"{stuWithId.Name} {stuWithId.Marks}");

//         //task 5: HashSet to store names
//         HashSet<string> names = new HashSet<string>();
//         Console.WriteLine(names.Add("Jay"));
//         Console.WriteLine(names.Add("Rahul"));
//         Console.WriteLine(names.Add("Jay"));
//         Console.WriteLine(names.Add("Amit"));
//         Console.WriteLine(names.Add("Rahul"));

//         Console.WriteLine(names.Count);

//         //task6: Exception Handling
//         try
//         {
//             Console.Write("Enter student ID: ");
//             int id = int.Parse(Console.ReadLine());

//             foreach(var stu in students)
//             {
//                 if(stu.Id == id)
//                 {
//                     Console.WriteLine($"student with {id} : {stu.Name}");
//                 }
//                 else
//                 {
//                     Console.WriteLine($"student not found with id: {id}");
//                 }
//             }
//         }
//         catch(FormatException)
//         {
//             Console.WriteLine("Invalid Id format.");
//         }

//     }
// }

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }

    public Student(int id, string name, int marks)
    {
        Id = id;
        Name = name;
        Marks = marks;
    }
}

class Program
{
    // Async operation returning a string
    static async Task<string> GenerateStudentReportAsync()
    {
        await Task.Delay(2000);

        return "Student report generated successfully.";
    }

    // Second async operation
    static async Task<string> GenerateAttendanceReportAsync()
    {
        await Task.Delay(2000);

        return "Attendance report generated successfully.";
    }

    static async Task Main()
    {
        // ==========================================
        // 1. LIST
        // ==========================================

        List<Student> students = new List<Student>
        {
            new Student(101, "Jagrati", 80),
            new Student(102, "Janvi", 95),
            new Student(103, "Jay", 73),
            new Student(104, "Jay K", 90),
            new Student(105, "Jay V", 40)
        };

        Console.WriteLine("===== ALL STUDENTS =====");

        foreach (Student student in students)
        {
            Console.WriteLine(
                $"ID: {student.Id}, Name: {student.Name}, Marks: {student.Marks}"
            );
        }


        // ==========================================
        // 2. FindAll + Lambda
        // ==========================================

        Console.WriteLine("\n===== PASSED STUDENTS =====");

        List<Student> passedStudents =
            students.FindAll(student => student.Marks >= 60);

        foreach (Student student in passedStudents)
        {
            Console.WriteLine(
                $"{student.Name} - {student.Marks}"
            );
        }


        // ==========================================
        // 3. Find + Lambda
        // ==========================================

        Console.WriteLine("\n===== FIRST STUDENT WITH 90+ =====");

        Student topper =
            students.Find(student => student.Marks >= 90);

        if (topper != null)
        {
            Console.WriteLine(
                $"{topper.Name} - {topper.Marks}"
            );
        }


        // ==========================================
        // 4. DICTIONARY
        // ==========================================

        Console.WriteLine("\n===== DICTIONARY SEARCH =====");

        Dictionary<int, Student> studentDictionary =
            new Dictionary<int, Student>();

        foreach (Student student in students)
        {
            studentDictionary[student.Id] = student;
        }

        Console.Write("Enter Student ID: ");

        try
        {
            int id = int.Parse(Console.ReadLine());

            if (studentDictionary.TryGetValue(id, out Student student))
            {
                Console.WriteLine(
                    $"Student Found: {student.Name}, Marks: {student.Marks}"
                );
            }
            else
            {
                Console.WriteLine(
                    $"Student with ID {id} not found."
                );
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid ID format. Please enter a number.");
        }


        // ==========================================
        // 5. HASHSET
        // ==========================================

        Console.WriteLine("\n===== HASHSET =====");

        HashSet<string> studentNames =
            new HashSet<string>();

        studentNames.Add("Jay");
        studentNames.Add("Rahul");
        studentNames.Add("Jay");
        studentNames.Add("Amit");
        studentNames.Add("Rahul");

        Console.WriteLine($"Unique names: {studentNames.Count}");

        foreach (string name in studentNames)
        {
            Console.WriteLine(name);
        }


        // ==========================================
        // 6. ASYNC / AWAIT
        // ==========================================

        Console.WriteLine("\n===== ASYNC REPORT =====");

        Console.WriteLine("Generating report...");

        string report =
            await GenerateStudentReportAsync();

        Console.WriteLine(report);


        // ==========================================
        // 7. TASK.WHENALL
        // ==========================================

        Console.WriteLine("\n===== MULTIPLE ASYNC OPERATIONS =====");

        Console.WriteLine("Generating reports...");

        Task<string> studentReportTask =
            GenerateStudentReportAsync();

        Task<string> attendanceReportTask =
            GenerateAttendanceReportAsync();

        string[] reports =
            await Task.WhenAll(
                studentReportTask,
                attendanceReportTask
            );

        foreach (string result in reports)
        {
            Console.WriteLine(result);
        }

        Console.WriteLine("\n===== PROGRAM COMPLETED =====");
    }
}