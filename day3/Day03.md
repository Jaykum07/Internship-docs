# Day 03 — C# Collections + Modern C#

## Objective

Understand and practically use C# collections, generics, lambda expressions, exception handling, structs, and asynchronous programming with `Task`, `async/await`, and `Task.WhenAll()`.

---

## 1. Arrays

An array stores a fixed-size collection of elements of the same type.

```csharp
int[] numbers = { 10, 20, 30, 40, 50 };
```

Key points:
- Fixed size
- Same data type
- Zero-based indexing
- Direct access by index

---

## 2. List<T>

`List<T>` is a dynamic collection whose size can grow or shrink.

```csharp
List<int> numbers = new List<int>();

numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
```

Examples:

```text
List<int>       -> integers
List<string>    -> strings
List<Student>   -> Student objects
```

Useful methods:

```csharp
numbers.Add(40);
numbers.Remove(20);
numbers.Count;
```

### FindAll()

Returns all matching elements.

```csharp
var result = numbers.FindAll(x => x > 20);
```

### Find()

Returns the first matching element.

```csharp
var result = students.Find(student => student.Marks >= 90);
```

Important:

```text
FindAll() -> potentially many results
Find()    -> first matching result
```

---

## 3. Dictionary<TKey, TValue>

A dictionary stores key-value pairs.

```csharp
Dictionary<int, Student> students =
    new Dictionary<int, Student>();
```

Here:

```text
Key   -> int
Value -> Student
```

Example:

```csharp
students[101] = student;
```

Safer lookup:

```csharp
if (students.TryGetValue(101, out Student student))
{
    Console.WriteLine(student.Name);
}
```

### Why Dictionary?

When we frequently search using a unique key, such as `StudentId`, a dictionary naturally models:

```text
Student ID -> Student
```

instead of repeatedly scanning a list.

---

## 4. HashSet<T>

A `HashSet<T>` stores unique values.

```csharp
HashSet<string> names = new HashSet<string>();

names.Add("Jay");
names.Add("Rahul");
names.Add("Jay");
```

The duplicate `"Jay"` is ignored.

```csharp
Console.WriteLine(names.Count);
```

Output:

```text
2
```

`Add()` returns a `bool`:

```csharp
names.Add("Jay"); // true if newly added
names.Add("Jay"); // false if already present
```

Use a HashSet when uniqueness matters.

---

## 5. Generics

Generics allow reusable code with a specified type.

Examples:

```csharp
List<int>
List<string>
List<Student>

Dictionary<int, Student>
HashSet<string>
```

The type is specified inside `< >`.

---

## 6. Lambda Expressions

A lambda is a compact way to represent an operation.

```csharp
x => x * 2
```

Meaning:

```text
x   -> input
=>  -> lambda operator
x*2 -> expression performed on x
```

Example:

```csharp
var evenNumbers =
    numbers.FindAll(x => x % 2 == 0);
```

Student example:

```csharp
var passedStudents =
    students.FindAll(student => student.Marks >= 60);
```

---

## 7. var

`var` lets the compiler infer the variable's type.

```csharp
var number = 10;
```

The compiler knows `number` is an `int`.

`var` is still strongly typed; it does not mean dynamic typing.

---

## 8. Struct vs Class

A `struct` is a value type.

A `class` is a reference type.

Example:

```csharp
struct Point
{
    public int X;
}

Point p1 = new Point();
p1.X = 10;

Point p2 = p1;
p2.X = 20;

Console.WriteLine(p1.X);
```

Output:

```text
10
```

Why?

```text
p2 = p1
   ↓
value is copied
   ↓
p1 and p2 have independent values
```

For classes:

```csharp
Student s2 = s1;
```

the reference is copied, so both variables can refer to the same object.

Mental model:

```text
Class  -> reference copied
Struct -> value copied
```

---

## 9. Exception Handling

Exception handling allows runtime errors to be handled without abruptly terminating the program.

```csharp
try
{
    // risky operation
}
catch (FormatException)
{
    // handle error
}
```

Example:

```csharp
try
{
    int age = int.Parse("abc");
}
catch (FormatException)
{
    Console.WriteLine("Invalid age");
}
```

Flow:

```text
try
 ↓
exception occurs
 ↓
catch
 ↓
program continues
```

### finally

`finally` runs whether an exception occurs or not.

```csharp
try
{
    // code
}
catch
{
    // error handling
}
finally
{
    // cleanup
}
```

### throw

`throw` explicitly raises an exception and is useful for enforcing business rules.

---

## 10. async / await

`async` and `await` are used with asynchronous operations.

```csharp
static async Task<string> GenerateReportAsync()
{
    await Task.Delay(2000);

    return "Report generated successfully";
}
```

Calling it:

```csharp
string report = await GenerateReportAsync();
```

Mental model:

```text
async method
     ↓
execute normally
     ↓
await
     ↓
this method pauses
     ↓
Task completes
     ↓
method resumes
```

---

## 11. Task vs Task<T>

### Task

Represents an asynchronous operation without a result.

```csharp
static async Task SaveDataAsync()
{
    await Task.Delay(1000);
}
```

### Task<T>

Represents an asynchronous operation that eventually produces a value.

```csharp
static async Task<int> GetNumberAsync()
{
    await Task.Delay(1000);
    return 100;
}
```

Then:

```csharp
int number = await GetNumberAsync();
```

Mental model:

```text
Task<int>
   ↓ await
 int
```

`Task<int>` is not the `int` itself. It represents an operation that will eventually produce an `int`.

---

## 12. Sequential vs Concurrent Async Operations

Sequential:

```csharp
var user = await GetUserAsync();
var orders = await GetOrdersAsync();
```

If both take approximately 2 seconds:

```text
GetUser   -> 2 sec
GetOrders -> 2 sec

Total ≈ 4 sec
```

If they are independent, start both first:

```csharp
var userTask = GetUserAsync();
var orderTask = GetOrdersAsync();

await Task.WhenAll(userTask, orderTask);
```

Approximately:

```text
GetUser  -> ████████ 2 sec
GetOrders-> ████████ 2 sec

Total ≈ 2 sec
```

This is useful for independent I/O operations such as API calls, database operations, and network operations.

---

## 13. Task.WhenAll()

`Task.WhenAll()` waits for multiple asynchronous operations.

JavaScript connection:

```text
JavaScript          C#
────────────────────────────
Promise             Task
Promise<number>     Task<int>
Promise.all()       Task.WhenAll()
await promise       await task
```

Example:

```csharp
Task<string> studentTask =
    GenerateStudentReportAsync();

Task<string> attendanceTask =
    GenerateAttendanceReportAsync();

string[] reports =
    await Task.WhenAll(
        studentTask,
        attendanceTask
    );
```

Important rule:

> Run independent I/O operations concurrently, but respect dependencies between operations.

---

# 14. Day 3 Mini Project — Student Performance Analyzer

The project combines the major Day 3 concepts.

## Student Model

```csharp
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
```

## List

```csharp
List<Student> students = new List<Student>
{
    new Student(101, "Jagrati", 80),
    new Student(102, "Janvi", 95),
    new Student(103, "Jay", 73),
    new Student(104, "Jay K", 90),
    new Student(105, "Jay V", 40)
};
```

## FindAll

```csharp
List<Student> passedStudents =
    students.FindAll(student => student.Marks >= 60);
```

## Find

```csharp
Student topper =
    students.Find(student => student.Marks >= 90);
```

Note: `Find()` returns the first student matching the condition. It does not necessarily calculate the highest mark.

## Dictionary

```csharp
Dictionary<int, Student> studentDictionary =
    new Dictionary<int, Student>();

foreach (Student student in students)
{
    studentDictionary[student.Id] = student;
}
```

## TryGetValue

```csharp
if (studentDictionary.TryGetValue(id, out Student student))
{
    Console.WriteLine(student.Name);
}
else
{
    Console.WriteLine("Student not found.");
}
```

## HashSet

```csharp
HashSet<string> studentNames =
    new HashSet<string>();

studentNames.Add("Jay");
studentNames.Add("Rahul");
studentNames.Add("Jay");
studentNames.Add("Amit");
studentNames.Add("Rahul");
```

Only unique names are stored.

## Exception handling

```csharp
try
{
    int id = int.Parse(Console.ReadLine());
}
catch (FormatException)
{
    Console.WriteLine("Invalid ID format.");
}
```

## Async report

```csharp
static async Task<string> GenerateStudentReportAsync()
{
    await Task.Delay(2000);

    return "Student report generated successfully.";
}
```

## Multiple async operations

```csharp
Task<string> studentReportTask =
    GenerateStudentReportAsync();

Task<string> attendanceReportTask =
    GenerateAttendanceReportAsync();

string[] reports =
    await Task.WhenAll(
        studentReportTask,
        attendanceReportTask
    );
```

---

# Day 3 End Test

**Score: 9/10**

Successfully demonstrated:

- Arrays
- `List<T>`
- `Dictionary<TKey,TValue>`
- `HashSet<T>`
- Generics
- Lambda expressions
- `var`
- Struct vs class
- Exception handling
- `Task`
- `Task<T>`
- `async/await`
- `Task.WhenAll()`
- Sequential vs concurrent asynchronous operations

### Main correction

For multiple operations:

> Run independent I/O operations concurrently, but respect dependencies between operations.

Example:

```text
GetUser ──────────┐
GetOrders ────────┤
                  ↓
               WhenAll
                  ↓
        Call notification API
```

if the notification API needs the user/order results.

---

# Interview-Ready Summary

### List vs Dictionary

```text
List       -> collection, indexing, iteration
Dictionary -> key-based lookup
```

### List vs HashSet

```text
List       -> duplicates allowed
HashSet    -> unique values
```

### Task vs Task<T>

```text
Task       -> async operation, no result
Task<T>    -> async operation that produces T
```

### async/await

```text
async -> method can use await
await -> asynchronously wait for a Task
```

### Task.WhenAll

```text
Start independent Tasks
        ↓
Task.WhenAll()
        ↓
wait for all
```

### Struct vs Class

```text
Struct -> value type
Class  -> reference type
```

---

# Git Checkpoint

Review the Day 3 implementation and ensure it runs successfully.

Suggested commit:

```text
day-03: complete C# collections and async practice
```

Commit the completed Day 3 work.

---

# Day 3 Status

**Completed ✅**

You moved from individual C# concepts to combining them into a working console application.

**Next: Day 4 according to the internship roadmap.**
