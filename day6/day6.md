# Day 6 — ASP.NET Core + HTTP + REST API

## Status
**Day 6 completed — PASS ✅**

**Final test score:** 8.4/10

## 1. What I Learned Today

### ASP.NET Core
- Created an ASP.NET Core Web API project.
- Understood `Program.cs` and the application pipeline.
- Learned controllers and `ControllerBase`.
- Learned `[ApiController]`.
- Learned routing with `[Route("api/[controller]")]`.

### HTTP + REST
- Request and response.
- URL and routing.
- REST API basics.
- GET, POST, PUT, DELETE.
- Status codes: `200 OK`, `201 Created`, `204 No Content`, `404 Not Found`.

### CRUD API
Built:
```text
GET     /api/Student
GET     /api/Student/{id}
POST    /api/Student
PUT     /api/Student/{id}
DELETE  /api/Student/{id}
```

### C# / ASP.NET Core Syntax
- `IActionResult`
- `Ok()`
- `NotFound()`
- `CreatedAtAction()`
- `NoContent()`
- `FirstOrDefault()`
- Lambda expressions
- `students.Add()`
- `students.Remove()`
- Route parameters
- Model binding

### Testing
- Swagger/OpenAPI ✅
- Postman ✅

## 2. Practical Work Completed

### GET
- Get all students.
- Get student by ID.
- Return `404` when not found.

### POST
- Receive request body through model binding.
- Create and add a student.
- Return `201 Created`.
- Used `CreatedAtAction()`.

### PUT
- Receive ID from route.
- Receive updated student from body.
- Find and update the existing object.

### DELETE
- Receive ID.
- Find the student.
- Return `404` if missing.
- Remove the student.

## 3. Important Concepts

### Model Binding
JSON request body:

```json
{
  "name": "Rahul",
  "marks": 88
}
```

is automatically bound to:

```csharp
Student student
```

This is **Model Binding**.

Compared with Node.js, instead of manually using `req.body`, ASP.NET Core can provide the object directly as an action parameter.

### Route Parameter
For:

```text
PUT /api/Student/5
```

```csharp
public IActionResult UpdateStudent(int id, Student student)
```

- `id = 5` comes from the route.
- `student` comes from the request body.

### FirstOrDefault()
```csharp
var student = students.FirstOrDefault(s => s.Id == id);
```

- Finds the first matching object.
- `s => s.Id == id` is a lambda expression.
- Returns `null` for a missing `Student`.

## 4. Node.js / ASP.NET Core Comparison

| Node.js / Express | ASP.NET Core |
|---|---|
| `app.get()` | `[HttpGet]` |
| `app.post()` | `[HttpPost]` |
| `app.put()` | `[HttpPut]` |
| `app.delete()` | `[HttpDelete]` |
| `req.params.id` | `int id` |
| `req.body` | `Student student` |
| `res.status(200).json()` | `Ok()` |
| `res.status(201).json()` | `Created()` / `CreatedAtAction()` |
| `res.status(404)` | `NotFound()` |
| Express Router | Controller + attributes |

Main takeaway:

> **Express:** I usually access data through `req`.  
> **ASP.NET Core:** model binding can provide request data directly to method parameters.

# 5. Weak Topics — Detailed Revision

## Weak Topic 1 — ControllerBase

I forgot what `ControllerBase` provides.

```csharp
public class StudentController : ControllerBase
```

The `:` means inheritance.

`ControllerBase` is the base class for ASP.NET Core API controllers and provides methods such as:

```csharp
Ok()
NotFound()
Created()
NoContent()
BadRequest()
```

### Interview answer
> `ControllerBase` is the base class for ASP.NET Core API controllers. We inherit from it so the controller can use API-related functionality such as `Ok()`, `NotFound()`, `Created()`, and `NoContent()`.

---

## Weak Topic 2 — [ApiController]

I initially thought `[ApiController]` mainly means CRUD.

Correct understanding:

```csharp
[ApiController]
public class StudentController : ControllerBase
```

It marks the class as an API controller and enables API-specific behavior such as automatic model validation and improved parameter binding.

### Remember
> `[ApiController]` = API-specific controller behavior, not CRUD.

---

## Weak Topic 3 — Constructor Injection

I forgot this during the test.

```csharp
public StudentManager(StudentService service)
{
    Service = service;
}
```

It is called **Constructor Injection** because the dependency is provided through the constructor.

The class does not create the dependency itself.

```text
DI Container
    ↓
creates StudentService
    ↓
creates StudentManager
    ↓
passes StudentService into constructor
```

### Interview answer
> It is called Constructor Injection because the dependency is provided through the class constructor. The ASP.NET Core DI container creates and provides the service instance.

---

## Weak Topic 4 — Dependency Injection Lifetimes

### Transient
```csharp
builder.Services.AddTransient<StudentService>();
```

A new instance is created whenever the service is requested.

### Scoped
One instance is created within a scope, commonly one HTTP request.

### Singleton
One instance is reused for the application's lifetime.

### Remember
```text
Transient → New every time requested
Scoped    → One per scope/request
Singleton → One for application lifetime
```

---

## Weak Topic 5 — CreatedAtAction()

I understood it as a proper response, but my explanation was not precise.

```csharp
return CreatedAtAction(
    nameof(GetStudentById),
    new { id = stu.Id },
    stu
);
```

It communicates:

```text
201 Created
+
created resource
+
location/action for retrieving it
```

### Remember
> **CreatedAtAction = resource created + retrieval location**

It is more specific than simply returning:

```csharp
Ok(stu)
```

---

## Weak Topic 6 — Request Flow

My first explanation was too short.

### GET flow

```text
Client
  ↓
ASP.NET Core application
  ↓
Middleware pipeline
  ↓
Routing
  ↓
StudentController
  ↓
[HttpGet("{id}")]
  ↓
id = 5
  ↓
Find student
  ↓
Ok(student) OR NotFound()
  ↓
HTTP response
  ↓
Client
```

### POST flow

```text
Client
  ↓
POST /api/Student
  ↓
Middleware pipeline
  ↓
Routing
  ↓
StudentController
  ↓
[HttpPost]
  ↓
Model Binding
  ↓
Student object
  ↓
Create/Add student
  ↓
CreatedAtAction()
  ↓
201 Created
  ↓
Client
```

### Important
In this Day 6 project, students are stored in an **in-memory list**, not a real database.

# 6. Revision Priority

### 🔴 High Priority
1. `ControllerBase`
2. `[ApiController]`
3. Constructor Injection
4. DI lifetimes
5. `CreatedAtAction()`
6. ASP.NET Core request flow

### 🟡 Medium Priority
7. `IActionResult`
8. HTTP status codes
9. Routing attributes
10. Model binding

### 🟢 Strong
11. GET / POST / PUT / DELETE
12. CRUD logic
13. `FirstOrDefault()`
14. Lambda expressions
15. Swagger/Postman testing

# 7. Final Day 6 Interview Performance

**Final Score: 8.4/10**

### Strong
- HTTP methods
- POST vs PUT
- Model binding
- Route parameters
- `FirstOrDefault()`
- CRUD implementation
- Status codes
- ASP.NET vs Node.js syntax

### Weak
- `ControllerBase`
- `[ApiController]`
- Constructor Injection
- Some DI concepts
- Precise `CreatedAtAction()` explanation
- Complete request pipeline explanation

# 8. Final Reflection

Today I built the complete Student CRUD API myself.

The biggest difference from Node.js is that ASP.NET Core handles more things through **attributes, method parameters, model binding, controllers and dependency injection**, instead of manually accessing everything through `req` and `res`.

My main goal for revision:

> **Understand ASP.NET Core syntax deeply instead of only remembering what the code does.**

## Day 6 Final Status

**Learning tasks: COMPLETE ✅**

**CRUD API: COMPLETE ✅**

**Swagger: COMPLETE ✅**

**Postman: COMPLETE ✅**

**Final interview test: COMPLETE ✅**

**Day 6: CLOSED 🟢**
