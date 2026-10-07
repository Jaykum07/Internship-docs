# Day 6 — ASP.NET Core + HTTP + REST API

## 🎯 Day Objective

Understand how ASP.NET Core handles HTTP requests and build a basic REST API using:

- ASP.NET Core
- HTTP
- REST
- Routing
- Controllers
- Actions
- Model Binding
- HTTP Methods
- HTTP Status Codes
- Swagger
- Postman
- CRUD operations

The main goal is to understand the complete flow:

```text
Client
   ↓
HTTP Request
   ↓
ASP.NET Core
   ↓
Routing
   ↓
Controller
   ↓
Action Method
   ↓
Data / Logic
   ↓
HTTP Response
   ↓
Client
```

---

# 1. What is ASP.NET Core?

ASP.NET Core is a framework from Microsoft used to build:

- Web APIs
- Web applications
- Backend services
- REST APIs
- Web applications using MVC

For this internship, the important part is:

> ASP.NET Core can be used to build backend APIs that receive HTTP requests and return HTTP responses.

### Node.js / Express comparison

In Node.js:

```javascript
app.get("/students", (req, res) => {
    res.json(students);
});
```

In ASP.NET Core:

```csharp
[HttpGet]
public IActionResult GetStudents()
{
    return Ok(students);
}
```

The idea is similar.

The syntax and framework structure are different.

---

# 2. What is HTTP?

HTTP stands for:

> HyperText Transfer Protocol

It is the communication protocol used between a client and a server.

Example:

```text
Frontend
   ↓
HTTP Request
   ↓
Backend API
   ↓
HTTP Response
   ↓
Frontend
```

For example:

```text
GET /api/Student
```

The client is asking the server:

> Give me the students.

The server may respond:

```text
200 OK
```

with JSON data.

---

# 3. HTTP Request

An HTTP request contains information such as:

- HTTP method
- URL
- Route parameters
- Headers
- Body

Example:

```http
POST /api/Student
Content-Type: application/json
```

Body:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

---

# 4. HTTP Response

The server sends an HTTP response.

A response contains things such as:

- Status code
- Headers
- Response body

Example:

```text
200 OK
```

Body:

```json
{
    "id": 1,
    "name": "Rahul",
    "marks": 88
}
```

---

# 5. Important HTTP Methods

REST APIs commonly use these methods:

| Method | Purpose |
|---|---|
| GET | Read data |
| POST | Create data |
| PUT | Update data |
| DELETE | Delete data |

### GET

Used to retrieve data.

```text
GET /api/Student
```

### POST

Used to create new data.

```text
POST /api/Student
```

### PUT

Used to update existing data.

```text
PUT /api/Student/1
```

### DELETE

Used to delete data.

```text
DELETE /api/Student/1
```

---

# 6. What is REST?

REST is an architectural style for designing APIs.

A REST API usually represents resources.

For example:

```text
/api/Student
```

represents students.

Different HTTP methods perform different operations on the resource:

```text
GET     /api/Student
POST    /api/Student

GET     /api/Student/1
PUT     /api/Student/1
DELETE  /api/Student/1
```

---

# 7. Controller

A controller handles HTTP requests.

Example:

```csharp
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
}
```

The controller is responsible for things such as:

- Receiving requests
- Calling appropriate logic
- Returning HTTP responses

A controller should not contain all business logic.

That separation becomes important on Day 7.

---

# 8. ControllerBase

Our controller inherits from:

```csharp
ControllerBase
```

Example:

```csharp
public class StudentController : ControllerBase
{
}
```

`ControllerBase` provides useful methods for API responses.

For example:

```csharp
Ok()
NotFound()
CreatedAtAction()
NoContent()
BadRequest()
```

Example:

```csharp
return Ok(student);
```

---

# 9. [ApiController]

We use:

```csharp
[ApiController]
```

above the controller.

Example:

```csharp
[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
}
```

`[ApiController]` enables API-specific behavior such as improved model binding and validation behavior.

It helps ASP.NET Core treat the class as an API controller.

---

# 10. Routing

Routing determines which controller/action should handle a request.

Example:

```csharp
[Route("api/[controller]")]
```

If the controller is:

```csharp
StudentController
```

then:

```text
[controller]
```

becomes:

```text
Student
```

Therefore the base route becomes:

```text
/api/Student
```

---

# 11. Route Parameter

Example:

```csharp
[HttpGet("{id}")]
public IActionResult GetStudentById(int id)
{
}
```

The route is:

```text
GET /api/Student/1
```

Here:

```text
1
```

is the `id`.

ASP.NET Core binds it to:

```csharp
int id
```

---

# 12. Model Binding

Model binding converts incoming HTTP request data into C# parameters/objects.

Example request:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

Controller:

```csharp
[HttpPost]
public IActionResult AddStudent(Student student)
{
}
```

ASP.NET Core automatically creates a `Student` object from the request body.

So:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

becomes something like:

```csharp
Student student
```

with:

```text
student.Name  → Rahul
student.Marks → 88
```

This is one major difference from Express.

In Express, we commonly access:

```javascript
req.body
req.params
```

In ASP.NET Core, model binding can directly provide the values to method parameters.

---

# 13. Student Model

Our API uses this model:

```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}
```

This represents a student.

Example object:

```json
{
    "id": 1,
    "name": "John Doe",
    "marks": 85
}
```

---

# 14. In-Memory Data

For practice, we stored students in a C# list:

```csharp
private List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "John Doe", Marks = 85 },
    new Student { Id = 2, Name = "Jane Smith", Marks = 92 },
    new Student { Id = 3, Name = "Alice Johnson", Marks = 78 }
};
```

This is only temporary memory.

If the application restarts, the data is recreated.

For example:

```text
Application starts
      ↓
List created
      ↓
POST Rahul
      ↓
Rahul exists
      ↓
Application stops
      ↓
Data is lost
```

A database will later provide persistent storage.

---

# 15. GET — Get All Students

Code:

```csharp
[HttpGet]
public IActionResult GetStudents()
{
    return Ok(students);
}
```

Request:

```text
GET /api/Student
```

Response:

```text
200 OK
```

with the student list.

---

# 16. GET — Get Student By ID

Code:

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

Request:

```text
GET /api/Student/2
```

The code searches for a student whose ID is `2`.

---

# 17. FirstOrDefault()

This was an important C# method used in our API.

```csharp
students.FirstOrDefault(s => s.Id == id);
```

Meaning:

> Find the first student whose ID matches the requested ID.

If found:

```text
Student object
```

If not found:

```text
null
```

That's why we check:

```csharp
if (student == null)
{
    return NotFound();
}
```

---

# 18. POST — Create Student

Code:

```csharp
[HttpPost]
public IActionResult AddStudent(Student student)
{
    Student stu = new Student
    {
        Id = students.Count() + 1,
        Name = student.Name,
        Marks = student.Marks
    };

    students.Add(stu);

    return CreatedAtAction(
        nameof(GetStudentById),
        new { id = stu.Id },
        stu
    );
}
```

Request:

```text
POST /api/Student
```

Body:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

Response:

```text
201 Created
```

Example:

```json
{
    "id": 4,
    "name": "Rahul",
    "marks": 88
}
```

---

# 19. CreatedAtAction()

We used:

```csharp
CreatedAtAction(...)
```

It is commonly used after successfully creating a resource.

It returns:

```text
201 Created
```

and can point to the endpoint used to retrieve the newly created resource.

Example:

```csharp
return CreatedAtAction(
    nameof(GetStudentById),
    new { id = stu.Id },
    stu
);
```

Think:

```text
Resource created
       +
Here is the created resource
       +
Here is where you can retrieve it
```

---

# 20. Important Note About ID Generation

We used:

```csharp
students.Count() + 1
```

This is only for practice.

It is not a reliable ID-generation strategy.

For example:

```text
1
2
3
4
```

If ID 4 is deleted, the count becomes 3.

A future POST could again generate:

```text
4
```

Also, because the data is in memory, IDs reset when the application restarts.

A real database should manage persistent IDs.

---

# 21. PUT — Update Student

Code:

```csharp
[HttpPut("{id}")]
public IActionResult UpdateById(int id, Student student)
{
    var stu = students.FirstOrDefault(stud => stud.Id == id);

    if (stu == null)
        return NotFound();

    stu.Name = student.Name;
    stu.Marks = student.Marks;

    return Ok(stu);
}
```

Request:

```text
PUT /api/Student/1
```

Body:

```json
{
    "name": "Updated John",
    "marks": 95
}
```

The `id` comes from the route:

```text
/1
```

The new student information comes from the body.

---

# 22. DELETE — Delete Student

Code:

```csharp
[HttpDelete("{id}")]
public IActionResult DeleteStudent(int id)
{
    var stu = students.FirstOrDefault(stu => stu.Id == id);

    if (stu == null)
        return NotFound();

    students.Remove(stu);

    return Ok("Student Deleted Successfully");
}
```

Request:

```text
DELETE /api/Student/1
```

If student exists:

```text
200 OK
```

If student doesn't exist:

```text
404 Not Found
```

Another common REST response for DELETE is:

```text
204 No Content
```

when there is no response body.

---

# 23. Important HTTP Status Codes

| Status | Meaning |
|---|---|
| 200 | Request successful |
| 201 | Resource created |
| 204 | Successful, no response body |
| 400 | Bad request |
| 401 | Unauthorized |
| 403 | Forbidden |
| 404 | Resource not found |
| 500 | Internal server error |

Important examples from our project:

```csharp
return Ok();
```

→ `200`

```csharp
return CreatedAtAction(...);
```

→ `201`

```csharp
return NoContent();
```

→ `204`

```csharp
return NotFound();
```

→ `404`

---

# 24. IActionResult

Our methods commonly return:

```csharp
IActionResult
```

Why?

Because one action may return different HTTP responses.

For example:

```csharp
if (student == null)
    return NotFound();

return Ok(student);
```

The same method can return:

```text
200 OK
```

or:

```text
404 Not Found
```

So `IActionResult` gives flexibility for different HTTP responses.

---

# 25. Route Parameter vs Request Body

This distinction is important.

Example:

```text
PUT /api/Student/5
```

Here:

```text
5
```

comes from the route.

The request body might be:

```json
{
    "name": "Rahul",
    "marks": 90
}
```

So:

```text
id     → Route
name   → Body
marks  → Body
```

In controller:

```csharp
public IActionResult UpdateById(int id, Student student)
```

ASP.NET Core binds both automatically.

---

# 26. Swagger

Swagger gives us an interactive API documentation/testing UI.

It allows us to:

- See available endpoints
- See HTTP methods
- Enter parameters
- Enter request bodies
- Execute requests
- See responses
- Check status codes

Example endpoints:

```text
GET     /api/Student
GET     /api/Student/{id}
POST    /api/Student
PUT     /api/Student/{id}
DELETE  /api/Student/{id}
```

Swagger was useful for testing the API without building a frontend.

---

# 27. Postman

Postman is another tool for testing APIs.

We tested:

```text
GET
POST
PUT
DELETE
```

Example POST:

```text
POST http://localhost:xxxx/api/Student
```

Body:

```json
{
    "name": "Rahul",
    "marks": 88
}
```

Postman helps us test backend APIs independently from the frontend.

---

# 28. Swagger vs Postman

| Swagger | Postman |
|---|---|
| API documentation + testing | API testing tool |
| Usually generated from API | Requests are manually created |
| Easy for exploring API | Powerful for API testing |
| Available inside/alongside API setup | Separate application |

Both are useful during backend development.

---

# 29. Our Student API Architecture

Day 6 version:

```text
StudentAPI
│
├── Controllers
│   └── StudentController.cs
│
├── Models
│   └── Student.cs
│
└── Program.cs
```

The controller currently contains the API logic.

Example:

```text
Request
   ↓
StudentController
   ↓
List<Student>
   ↓
Response
```

On Day 7, we improve this architecture by separating business logic into a Service layer.

---

# 30. Complete CRUD Flow

## Create

```text
POST
 ↓
Controller
 ↓
Create Student
 ↓
201 Created
```

## Read

```text
GET
 ↓
Controller
 ↓
Find Student(s)
 ↓
200 OK
```

## Update

```text
PUT
 ↓
Controller
 ↓
Find Student
 ↓
Update
 ↓
200 OK
```

## Delete

```text
DELETE
 ↓
Controller
 ↓
Find Student
 ↓
Remove
 ↓
200 OK / 204
```

---

# 31. ASP.NET Core vs Express

| Express / Node.js | ASP.NET Core |
|---|---|
| `app.get()` | `[HttpGet]` |
| `app.post()` | `[HttpPost]` |
| `req.params` | Route/model binding |
| `req.body` | Model binding |
| `res.json()` | `Ok()` |
| `res.status(404)` | `NotFound()` |
| Middleware | Middleware |
| npm | NuGet |
| JavaScript | C# |
| Express Router | ASP.NET Core routing/controllers |

The backend concepts are very similar.

The biggest difference is framework structure and C# syntax.

---

# 32. Complete Request Flow

This is one of the most important concepts from Day 6.

Suppose the client sends:

```text
GET /api/Student/2
```

Flow:

```text
Client
   ↓
HTTP Request
   ↓
ASP.NET Core
   ↓
Routing
   ↓
StudentController
   ↓
GetStudentById(2)
   ↓
Find student in data
   ↓
Student found?
   ↓
Yes → 200 OK
No  → 404 Not Found
```

Later, the complete architecture will include middleware and services.

---

# 33. What I Understand Now

After Day 6, I should be able to explain:

- What ASP.NET Core is
- What HTTP is
- What REST API means
- GET / POST / PUT / DELETE
- Controller
- ControllerBase
- `[ApiController]`
- `[Route]`
- `[HttpGet]`
- `[HttpPost]`
- `[HttpPut]`
- `[HttpDelete]`
- Route parameters
- Request body
- Model binding
- `IActionResult`
- `Ok()`
- `NotFound()`
- `CreatedAtAction()`
- `NoContent()`
- HTTP status codes
- `FirstOrDefault()`
- Swagger
- Postman
- CRUD operations
- Basic request → response flow

---

# 34. Topics I Need to Revise

These were weaker areas during the Day 6 test:

### 1. ControllerBase

Remember:

```csharp
public class StudentController : ControllerBase
```

`ControllerBase` provides common API controller functionality such as:

```csharp
Ok()
NotFound()
CreatedAtAction()
NoContent()
BadRequest()
```

---

### 2. Complete Request Pipeline

Do not explain it only as:

```text
Request → Controller → Response
```

A better basic explanation:

```text
HTTP Request
     ↓
ASP.NET Core
     ↓
Middleware
     ↓
Routing
     ↓
Controller Action
     ↓
Logic / Data
     ↓
HTTP Response
```

---

### 3. CreatedAtAction()

Remember:

```text
201 Created
+
Created resource
+
Location/action to retrieve it
```

---

### 4. Difference Between In-Memory Data and Database

Our `List<Student>` is only temporary.

```text
Application restart
        ↓
Data resets
```

A database provides persistent storage.

---

# 35. Interview Questions to Practice

## Q1. What is ASP.NET Core?

Try to answer without looking at the document.

---

## Q2. What is a REST API?

Explain it using the Student API.

---

## Q3. Difference between GET and POST?

---

## Q4. Difference between PUT and POST?

---

## Q5. What is routing?

---

## Q6. What does `[Route("api/[controller]")]` mean?

---

## Q7. What is `[ApiController]`?

---

## Q8. What is ControllerBase?

---

## Q9. What is model binding?

---

## Q10. Where does `id` come from in:

```csharp
[HttpGet("{id}")]
public IActionResult GetStudentById(int id)
```

---

## Q11. Where does `Name` come from in:

```csharp
public IActionResult AddStudent(Student student)
```

---

## Q12. Why do we use `IActionResult`?

---

## Q13. Difference between 200, 201, 204 and 404?

---

## Q14. What is `FirstOrDefault()`?

---

## Q15. What is `CreatedAtAction()`?

---

## Q16. Why does our student data disappear after restarting the application?

---

## Q17. How is ASP.NET Core different from Express?

---

## Q18. Explain the complete request flow in ASP.NET Core.

---

# 36. Day 6 Final Mental Model

Keep this simple mental model:

```text
HTTP Request
      ↓
Routing
      ↓
Controller
      ↓
Action Method
      ↓
Get/Create/Update/Delete Data
      ↓
HTTP Response
```

And remember:

```text
GET     → Read
POST    → Create
PUT     → Update
DELETE  → Delete
```

```text
200 → Success
201 → Created
204 → Success, no body
404 → Not Found
```

```text
Route → /api/Student/5
Body  → { "name": "Rahul", "marks": 88 }
```

---

# 37. Day 7 Connection

Day 6 taught:

```text
Controller
   ↓
Logic
   ↓
Data
```

But putting everything inside the controller becomes difficult to maintain.

Day 7 improves it:

```text
Client
   ↓
Controller
   ↓
Service
   ↓
Data / Repository
```

The controller will focus on HTTP.

The service will focus on application/business logic.

This is why we are learning:

- Controller vs Service
- Interfaces
- Dependency Injection
- DTOs
- Validation
- Middleware
- Global error handling

---

# 🧠 Final Revision Rule

Do not memorize the code line-by-line.

Understand:

```text
What is happening?
Why is it happening?
Who is responsible for it?
What HTTP response should be returned?
```

If I can explain the request flow without looking at the code, I understand Day 6.
```