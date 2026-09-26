//string name = "Jay Kumrawat";
//string cllg = "JIT, Borawan";
//string goal = "Software Developer Engineer";

//Console.WriteLine($"Hello, my name is {name}. I studied at {cllg} and my goal is to become a {goal}.");


//int Add(int a, int b)
//{
//    return a + b;
//}

//int Subtract(int a, int b)
//{
//    return a - b;
//}

//int Multiply(int a, int b)
//{
//    return a * b;
//}

//int Divide(int a, int b)
//{
//    if(b == 0)
//    {
//        Console.WriteLine("denominator cannot be zero");
//        return 0;
//    }

//    return a / b;
//}

//Console.WriteLine("Enter numbers: ");
//if(int.TryParse(Console.ReadLine(), out int num1) && int.TryParse(Console.ReadLine(), out int num2))
//{
//    Console.WriteLine($"You Entered Numbers: {num1}, {num2}");

//    Console.WriteLine("Sum: " + Add(num1, num2));
//    Console.WriteLine("Substraction: " + Subtract(num1, num2));
//    Console.WriteLine("Multiplication: " + Multiply(num1, num2));
//    Console.WriteLine("Division: " + Divide(num1, num2));
//}
//else
//{
//    Console.WriteLine("Invalid Number");
//}

//Developer developer1 = new Developer("jay", "c#", "Beginner");

//Developer developer2 = new Developer("someone", "java", "intemidiate");


//Console.WriteLine("Developer 1: ");
//developer1.Introduce();


//Console.WriteLine("Developer 2: ");
//developer2.Introduce();

//public class Developer
//{
//    public string Name { get; set; }
//    public string Language { get; set; }
//    public string Experience { get; set; }

//    public Developer(string name, string language, string experience)
//    {
//        this.Name = name;
//        this.Language = language;
//        this.Experience = experience;
//    }

//    public void Introduce()
//    {
//        Console.WriteLine($"Name: {Name}");
//        Console.WriteLine($"Language: {Language}");
//        Console.WriteLine($"Experience: {Experience}");
//    }

//}

Student stu1 = new Student("Jay", 10, "Btech");
Console.WriteLine("Student 1: ");
stu1.DisplayDetails();
Student stu2 = new Student("someone", 10, "Mtech");
Console.WriteLine("Student 2: ");
stu2.DisplayDetails();

public class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }
    public string Course { get; set; }

    public Student(string name, int marks, string course)
    {
        this.Name = name;
        this.Marks = marks;
        this.Course = course;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Marks: {Marks}");
        Console.WriteLine($"Course: {Course}");

    }

}
