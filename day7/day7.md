
# Day 7 — ASP.NET Core API Architecture

## 🎯 Day Objective

Today the goal is to understand how to structure an ASP.NET Core API properly.

Day 6 focused on:

    Request
       ↓
    Controller
       ↓
    Data
       ↓
    Response

But putting all logic inside the controller becomes difficult to maintain.

Day 7 introduces:

- Controller vs Service
- Interface
- Dependency Injection
- Constructor Injection
- DTOs
- Model Binding
- Validation
- Middleware
- Global Error Handling
- Separation of Responsibilities

The improved architecture becomes:

    Client
       ↓
    Controller
       ↓
    Service
       ↓
    Data / Repository
       ↓
    Response


---

# 1. Why Do We Need Architecture?

Imagine our controller contains everything:

```text
StudentController
│
├── HTTP handling
├── Student searching
├── Student creation
├── Student updating
├── Student deletion
├── Validation
├── Business rules
└── Error handling
```

This works for a small practice project.

But in a real application, the controller can become very large.

Example:

```text
StudentController.cs
    1000+ lines
```

This becomes difficult to:

- Understand
- Test
- Maintain
- Modify
- Debug

So we separate responsibilities.


---

# 2. Separation of Responsibilities

The basic idea:

> One class should have one main responsibility.

For our API:

```text
Controller
    ↓
HTTP-related work

Service
    ↓
Business/application logic

Model
    ↓
Data structure

DTO
    ↓
Data transferred through API
```

This makes the application easier to maintain.


---

# 3. Controller vs Service

This is one of the most important concepts of Day 7.

## Controller

Controller handles HTTP-related responsibilities.

Examples:

```text
GET request
POST request
PUT request
DELETE request

Status codes
Route parameters
Request/response handling
```

Example:

```csharp
[HttpGet("{id}")]
public IActionResult GetStudentById(int id)
{
    var student = _studentService.GetStudentById(id);

    if (student == null)
        return NotFound();

    return Ok(student);
}
```

The controller decides:

```text
What HTTP response should I return?
```

---

# 4. Service

The service contains application/business logic.

Example:

```csharp
public Student? GetStudentById(int id)
{
    return students.FirstOrDefault(s => s.Id == id);
}
```

The service answers:

```text
How should I find the student?
```

It should not normally return:

```csharp
Ok()
NotFound()
BadRequest()
CreatedAtAction()
```

Those are HTTP concerns and belong in the controller.


---

# 5. Simple Rule

Remember:

```text
Controller → HTTP

Service → Business/Application Logic
```

Or:

```text
Controller:
"What response should the client receive?"

Service:
"What should the application do?"
```


---

# 6. Example — Wrong Architecture

Avoid putting business logic directly everywhere in the controller:

```csharp
[HttpGet("{id}")]
public IActionResult GetStudentById(int id)
{
    var student = students.FirstOrDefault(s => s.Id == id);

    if (student == null)
        return NotFound();

    return Ok(student);
}
```

For a small project this works.

But as the application grows, the controller becomes responsible for too much.


---

# 7. Better Architecture

Controller:

```csharp
[HttpGet("{id}")]
public IActionResult GetStudentById(int id)
{
    var student = _studentService.GetStudentById(id);

    if (student == null)
        return NotFound();

    return Ok(student);
}
```

Service:

```csharp
public Student? GetStudentById(int id)
{
    return students.FirstOrDefault(s => s.Id == id);
}
```

Now:

```text
Controller
    ↓
Service
    ↓
Data
```

Each layer has a clearer responsibility.


---

# 8. Services Folder

We created:

```text
StudentAPI
│
├── Controllers
│   └── StudentController.cs
│
├── Models
│   └── Student.cs
│
├── Services
│   ├── IStudentService.cs
│   └── StudentService.cs
│
└── Program.cs
```

The `Services` folder contains application logic.


---

# 9. Interface

We created:

```csharp
public interface IStudentService
{
    List<Student> GetStudents();
    Student GetStudentById(int id);
}
```

An interface defines a contract.

It says:

> Any class implementing this interface must provide these methods.

The interface does not contain the actual implementation.

Think:

```text
Interface
    ↓
Contract
```

and:

```text
StudentService
    ↓
Implementation
```


---

# 10. IStudentService

Our interface:

```csharp
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudentById(int id);
    }
}
```

It defines what the service can do.

It does not define how it does it.


---

# 11. StudentService

Our service implements the interface:

```csharp
public class StudentService : IStudentService
{
}
```

This means:

```text
StudentService
implements
IStudentService
```

The service contains the actual logic.

Example:

```csharp
public Student? GetStudentById(int id)
{
    var student = students.FirstOrDefault(s => s.Id == id);

    return student;
}
```

---

# 12. Why Interface?

Interfaces provide abstraction.

Instead of the controller depending directly on:

```text
StudentService
```

it depends on:

```text
IStudentService
```

This gives us loose coupling.

Think:

```text
Controller
    ↓
IStudentService
    ↓
StudentService
```

The controller knows what the service can do, but does not need to know all implementation details.


---

# 13. Dependency

A dependency is something a class needs to perform its work.

Example:

```csharp
public class StudentController
{
    private StudentService _studentService;
}
```

The controller depends on `StudentService`.

Why?

Because it needs the service to get student data.


---

# 14. Dependency Injection

Dependency Injection means:

> Instead of a class creating its dependency itself, the dependency is provided to it.

Without DI:

```csharp
public class StudentController
{
    private StudentService _studentService =
        new StudentService();
}
```

The controller creates the service itself.

With DI:

```csharp
public class StudentController
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
}
```

ASP.NET Core provides the dependency.

This is Dependency Injection.


---

# 15. Constructor Injection

The most common form of DI we are using is constructor injection.

Example:

```csharp
private readonly IStudentService _studentService;

public StudentController(IStudentService studentService)
{
    _studentService = studentService;
}
```

The dependency is received through the constructor.

Flow:

```text
ASP.NET Core
     ↓
Creates StudentController
     ↓
Sees IStudentService dependency
     ↓
Finds registered implementation
     ↓
Creates StudentService
     ↓
Passes it to constructor
```

This is called constructor injection.


---

# 16. Why readonly?

We use:

```csharp
private readonly IStudentService _studentService;
```

`readonly` means the field can be assigned during initialization/constructor and should not be reassigned later.

We don't want the controller to randomly replace its service dependency.

So:

```csharp
private readonly IStudentService _studentService;
```

is a common pattern.


---

# 17. Registering Dependency

ASP.NET Core needs to know:

```text
When someone asks for IStudentService,
which class should be provided?
```

We register it in `Program.cs`:

```csharp
builder.Services.AddScoped<IStudentService, StudentService>();
```

This means:

```text
IStudentService
       ↓
StudentService
```

When ASP.NET Core needs an `IStudentService`, it knows to provide a `StudentService`.


---

# 18. AddScoped

We use:

```csharp
builder.Services.AddScoped<IStudentService, StudentService>();
```

`Scoped` means:

> One service instance is created for a particular request/scope.

For a web API, this commonly means:

```text
Request 1
   ↓
StudentService instance A

Request 2
   ↓
StudentService instance B
```

Each request gets its own scoped instance.


---

# 19. DI Lifetimes

ASP.NET Core commonly provides three DI lifetimes.

## Transient

```csharp
AddTransient
```

A new instance is created each time it is requested.

Think:

```text
Request/Resolution
    ↓
New instance
```

---

## Scoped

```csharp
AddScoped
```

One instance per scope.

For web APIs, normally:

```text
One HTTP request
    ↓
One scoped instance
```

---

## Singleton

```csharp
AddSingleton
```

One instance is reused for the application's lifetime.

Think:

```text
Application starts
      ↓
One instance
      ↓
Reused
      ↓
Application stops
```

---

# 20. DI Lifetime Comparison

| Lifetime | Basic idea |
|---|---|
| Transient | New instance each time |
| Scoped | One instance per scope/request |
| Singleton | One instance for application lifetime |

For our StudentService:

```csharp
builder.Services.AddScoped<IStudentService, StudentService>();
```

is appropriate for our current learning example.


---

# 21. Complete DI Flow

Understand this instead of memorizing it.

```text
Client
   ↓
Request
   ↓
ASP.NET Core
   ↓
Create Controller
   ↓
Controller needs IStudentService
   ↓
DI Container
   ↓
Find registration
   ↓
IStudentService → StudentService
   ↓
Create/provide StudentService
   ↓
Inject into Controller
```

Then:

```text
Controller
   ↓
_studentService.GetStudentById(id)
   ↓
StudentService
   ↓
Data
```

---

# 22. DTO — Data Transfer Object

DTO stands for:

> Data Transfer Object

A DTO defines the data that should be transferred through an API.

Instead of always using the database/model object directly in the API, we can create a DTO.

Example:

```csharp
public class StudentCreateDto
{
    public string Name { get; set; }
    public int Marks { get; set; }
}
```

The client sends:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

The DTO represents the expected input.


---

# 23. Why DTO?

Suppose our model is:

```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}
```

But when creating a student, the client should not provide the ID.

The server/database should handle the ID.

So instead of accepting:

```json
{
    "id": 10,
    "name": "Rahul",
    "marks": 88
}
```

we can create:

```csharp
public class StudentCreateDto
{
    public string Name { get; set; }
    public int Marks { get; set; }
}
```

Now the client only sends:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

This gives better control over API input.


---

# 24. Model vs DTO

## Model

Represents application/domain data.

Example:

```csharp
Student
```

## DTO

Represents data transferred through an API.

Example:

```csharp
StudentCreateDto
StudentUpdateDto
StudentResponseDto
```

Simple mental model:

```text
Model → Application data

DTO → API data transfer
```


---

# 25. Different DTOs

We may have different DTOs for different operations.

Example:

```text
StudentCreateDto
    ↓
Data required to create student

StudentUpdateDto
    ↓
Data allowed to update student

StudentResponseDto
    ↓
Data returned to client
```

This avoids exposing unnecessary fields.


---

# 26. Model Binding + DTO

Controller:

```csharp
[HttpPost]
public IActionResult AddStudent(StudentCreateDto dto)
{
}
```

Request:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

ASP.NET Core model binding converts the request body into:

```text
StudentCreateDto
```

So:

```text
JSON
 ↓
Model Binding
 ↓
DTO object
```

---

# 27. Validation

Validation means checking whether incoming data is valid.

Example requirements:

```text
Name should not be empty
Marks should be between 0 and 100
```

We don't want:

```json
{
    "name": "",
    "marks": 500
}
```

to be accepted.

---

# 28. Data Annotations

ASP.NET Core supports validation attributes.

Example:

```csharp
using System.ComponentModel.DataAnnotations;

public class StudentCreateDto
{
    [Required]
    public string Name { get; set; }

    [Range(0, 100)]
    public int Marks { get; set; }
}
```

Meaning:

```text
[Required]
    ↓
Name must be provided

[Range(0, 100)]
    ↓
Marks must be between 0 and 100
```

---

# 29. Validation + [ApiController]

When using:

```csharp
[ApiController]
```

ASP.NET Core provides automatic API validation behavior.

If the incoming model is invalid, ASP.NET Core can automatically return:

```text
400 Bad Request
```

instead of us manually checking every validation error.

This is one reason `[ApiController]` is important.


---

# 30. Middleware

Middleware is code that participates in processing HTTP requests and responses.

Think of middleware as a pipeline.

```text
Request
   ↓
Middleware 1
   ↓
Middleware 2
   ↓
Middleware 3
   ↓
Controller
   ↓
Response
```

Middleware can:

- Log requests
- Handle authentication
- Handle authorization
- Handle exceptions
- Modify requests/responses
- Perform other cross-cutting tasks


---

# 31. Middleware Example

Conceptually:

```text
Request
   ↓
Logging Middleware
   ↓
Authentication Middleware
   ↓
Authorization Middleware
   ↓
Routing
   ↓
Controller
```

The request passes through the pipeline.


---

# 32. Why Middleware?

Imagine we want to log every request.

Without middleware, we might write logging code inside every controller.

That would create duplication.

Instead:

```text
Logging Middleware
       ↓
handles logging for all requests
```

This is a cross-cutting concern.


---

# 33. Global Error Handling

Applications can encounter unexpected errors.

Example:

```csharp
int result = 10 / 0;
```

We don't want every controller to contain:

```csharp
try
{
}
catch
{
}
```

for every operation.

Instead, we can use centralized/global error handling.

Concept:

```text
Request
   ↓
Middleware
   ↓
Controller
   ↓
Exception
   ↓
Global Exception Handling
   ↓
Proper HTTP Response
```

This keeps controllers cleaner.


---

# 34. Why Global Error Handling?

Without centralized handling:

```text
Controller 1 → try/catch
Controller 2 → try/catch
Controller 3 → try/catch
Controller 4 → try/catch
```

This becomes repetitive.

With global handling:

```text
All requests
     ↓
Global error handling
```

One central place handles unexpected exceptions.


---

# 35. Separation of Responsibilities

Our architecture now looks like:

```text
                    Client
                      ↓
                  Controller
                      ↓
                    DTO
                      ↓
                   Service
                      ↓
                 Data Layer
```

And middleware works around the request pipeline:

```text
Client
  ↓
Middleware
  ↓
Routing
  ↓
Controller
  ↓
Service
  ↓
Data
  ↓
Response
```

Each component has a different responsibility.


---

# 36. Student API — Day 7 Architecture

Our project becomes:

```text
StudentAPI
│
├── Controllers
│   └── StudentController.cs
│
├── Models
│   └── Student.cs
│
├── DTOs
│   ├── StudentCreateDto.cs
│   └── StudentUpdateDto.cs
│
├── Services
│   ├── IStudentService.cs
│   └── StudentService.cs
│
└── Program.cs
```

Later, with a database:

```text
StudentAPI
│
├── Controllers
├── DTOs
├── Models
├── Services
├── Repositories
├── Data
└── Program.cs
```


# 37. Request Flow — Final Day 7 Mental Model

Suppose the client sends:

```text
POST /api/Student
```

with:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

The conceptual flow is:

```text
Client
   ↓
HTTP Request
   ↓
Middleware
   ↓
Routing
   ↓
Controller
   ↓
Model Binding
   ↓
DTO
   ↓
Validation
   ↓
Service
   ↓
Business Logic
   ↓
Data
   ↓
Service returns result
   ↓
Controller
   ↓
HTTP Response
```

Example response:

```text
201 Created
```


# 38. Very Important: Who Does What?

| Component | Responsibility |
|---|---|
| Controller | HTTP/request/response handling |
| Service | Business/application logic |
| Interface | Contract |
| DTO | API data transfer |
| Model | Application/domain data |
| DI Container | Creates/provides dependencies |
| Middleware | Request/response pipeline concerns |
| Validation | Checks input correctness |
| Global Error Handling | Central exception handling |

Remember this table.


# 39. Common Mistakes

## Mistake 1 — Business logic inside Controller

Bad architecture:

```csharp
var student = students.FirstOrDefault(...);
```

everywhere in controller.

Better:

```csharp
var student = _studentService.GetStudentById(id);
```


## Mistake 2 — Returning HTTP responses from Service

Avoid:

```csharp
return NotFound();
```

inside the service.

Service should return:

```csharp
return null;
```

Controller decides:

```csharp
if (student == null)
    return NotFound();
```


## Mistake 3 — Controller directly creates Service

Avoid:

```csharp
new StudentService();
```

inside controller when using DI.

Use constructor injection.


## Mistake 4 — Exposing everything through API

Don't automatically expose every model property.

DTOs give control over API input/output.


# 40. Day 7 Key Concepts

Before moving forward, I should understand:

### Architecture

```text
Controller → Service → Data
```

### Interface

```text
Interface → Contract
Implementation → Actual logic
```

### Dependency Injection

```text
Dependency is provided instead of manually created.
```

### Constructor Injection

```csharp
public StudentController(IStudentService studentService)
{
    _studentService = studentService;
}
```

### DI Registration

```csharp
builder.Services.AddScoped<IStudentService, StudentService>();
```

### DTO

```text
Object used to transfer API data.
```

### Validation

```text
Check whether incoming data is valid.
```

### Middleware

```text
Code that participates in the HTTP request/response pipeline.
```

### Global Error Handling

```text
Centralized handling of unexpected exceptions.
```


# 41. Day 7 Interview Questions

## Basic

1. Why do we need a Service layer?
2. What is the difference between Controller and Service?
3. What is an interface?
4. Why do we use `IStudentService`?
5. What is Dependency Injection?
6. What is Constructor Injection?
7. What does `AddScoped()` mean?
8. Difference between Transient, Scoped and Singleton?
9. What is a DTO?
10. Why should we use DTOs?
11. Difference between Model and DTO?
12. What is Model Binding?
13. What is validation?
14. What is `[ApiController]`?
15. What is Middleware?
16. Why do we need Middleware?
17. What is Global Exception Handling?


# 42. Interview Scenario

Imagine an interviewer asks:

> "Why don't you put all your code inside the controller?"

Good answer:

```text
Because the controller should mainly handle HTTP-related responsibilities.
Business or application logic should be moved into the Service layer.
This keeps the code separated, easier to test, maintain and modify.
```

---

# 43. Interview Scenario — DI

Question:

> Why use Dependency Injection instead of creating StudentService manually?

Answer:

```text
Dependency Injection reduces tight coupling.
The controller depends on an abstraction such as IStudentService,
and ASP.NET Core provides the required implementation.
This makes the code easier to maintain and test.
```


# 44. Interview Scenario — DTO

Question:

> Why use DTO instead of directly accepting the model?

Answer:

```text
DTO allows us to control what data the API accepts or returns.
It prevents unnecessary model properties from being exposed
and gives us different structures for different API operations.
```


# 45. Interview Scenario — Middleware

Question:

> What is middleware?

Answer:

```text
Middleware is software that participates in the ASP.NET Core
request and response pipeline. It can be used for logging,
authentication, authorization, exception handling and other
cross-cutting concerns.
```


# 46. Final Day 7 Mental Model

Remember this:

```text
                 CLIENT
                    ↓
               HTTP Request
                    ↓
               MIDDLEWARE
                    ↓
                 ROUTING
                    ↓
               CONTROLLER
                    ↓
             MODEL BINDING
                    ↓
                   DTO
                    ↓
               VALIDATION
                    ↓
                 SERVICE
                    ↓
              BUSINESS LOGIC
                    ↓
                  DATA
                    ↓
                 SERVICE
                    ↓
               CONTROLLER
                    ↓
             HTTP RESPONSE
                    ↓
                 CLIENT
```


# 🧠 Day 7 Golden Rules

1. Controller handles HTTP.
2. Service handles application/business logic.
3. Interface defines a contract.
4. Dependency Injection provides dependencies.
5. Constructor Injection is a common DI pattern.
6. `AddScoped()` creates one instance per request/scope.
7. DTO controls API data transfer.
8. Model Binding converts request data into C# objects/parameters.
9. Validation checks incoming data.
10. Middleware participates in the HTTP pipeline.
11. Global error handling centralizes unexpected exceptions.
12. Keep responsibilities separated.


# 🚀 Day 7 Final Architecture

The most important thing to remember:

```text
HTTP Responsibility
        ↓
    Controller
        ↓
Application Logic
        ↓
     Service
        ↓
    Data Layer
```

And around this:

```text
Middleware
Validation
Dependency Injection
Error Handling
```

The goal is not to memorize every syntax.

The goal is to understand:

> "If I receive a request, which layer should handle which responsibility, and why?"
```

