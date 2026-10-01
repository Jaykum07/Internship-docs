# Day 05 — .NET Application Structure

## Date

**30 September 2026**

## Objective

Understand how a .NET application is structured and learn the basic concepts of configuration, logging, and Dependency Injection.

---

## 1. Console Application vs Web Application

### Console Application

A console application runs from the terminal and is mainly used for learning, utilities, scripts, and simple applications.

### Web Application

A web application runs as a server and communicates with clients through HTTP requests and responses.

Example:

```text
Client
  ↓ HTTP Request
.NET Web Application
  ↓
Response
  ↓
Client
```

---

## 2. Solution vs Project

### Solution

A solution can contain multiple projects.

```text
Solution
├── Project 1
├── Project 2
└── Project 3
```

### Project

A project contains the code and configuration required for a particular application or component.

**My understanding:**

> A solution contains multiple projects, and a project contains code for a particular task or application.

---

## 3. `.csproj` File

The `.csproj` file is the **project configuration file**.

It contains information such as:

* SDK
* Target framework
* Package references
* Project configuration

It helps .NET understand how to build and manage the project.

---

## 4. NuGet

NuGet is the package management system used in the .NET ecosystem.

It allows us to install and manage external packages that our application needs.

---

## 5. Application Structure

I learned why we separate different responsibilities instead of keeping everything in one file.

If everything is inside one file:

* Code becomes messy
* It becomes difficult to read
* It becomes difficult to maintain

We separate responsibilities into different parts.

### Model

Models define the structure of our data.

Example:

```csharp
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}
```

### Service

A service contains application logic and operations related to the data.

Example:

```csharp
class StudentService
{
    public string GetStudent()
    {
        Console.WriteLine("Getting Student..");
        return "";
    }
}
```

---

## 6. Configuration

I learned about application configuration and `appsettings.json`.

Configuration keeps application settings separate from the main application logic.

Examples of configuration can include:

* Database settings
* Application settings
* Logging configuration
* Other environment-related settings

### Important

Sensitive information should not be treated as normal configuration and should be handled securely.

---

## 7. Why Not Hard-Code Configuration?

If configuration is directly written inside application code, changing it may require changing the code.

Keeping configuration separately makes it easier to manage different environments.

Example:

```text
Development
    ↓
Development configuration

Production
    ↓
Production configuration
```

---

# 8. Logging

Logging helps developers and administrators understand what is happening inside an application.

It can record:

```text
INFO
WARNING
ERROR
```

Example:

```text
INFO    Application started
WARNING Student not found
ERROR   Database connection failed
```

The user may only see:

```text
Something went wrong.
```

But logs can help the developer identify the actual problem.

### My understanding

> Logging helps us identify errors, successes, failures, and problems inside the application.

---

# 9. Dependency

A dependency is something that one class needs to perform its work.

Example:

```text
StudentManager
      ↓ needs
StudentService
```

Here:

> `StudentService` is a dependency of `StudentManager`.

---

# 10. Tight Coupling

Initially, we created the service directly:

```csharp
class StudentManager
{
    public void Get()
    {
        StudentService service = new StudentService();
        service.GetStudent();
    }
}
```

The problem is that `StudentManager` is responsible for creating `StudentService`.

This creates tight coupling.

---

# 11. Constructor Injection

We changed the approach so that `StudentManager` receives `StudentService` through its constructor.

```csharp
class StudentManager
{
    private StudentService service;

    public StudentManager(StudentService service)
    {
        this.service = service;
    }

    public void Get()
    {
        service.GetStudent();
    }
}
```

Now `StudentManager` does not create `StudentService`.

It receives it from outside.

### Flow

```text
StudentService
      ↓
StudentManager constructor
      ↓
StudentManager uses service
```

---

# 12. Dependency Injection

My understanding:

> Dependency Injection means providing a class with the dependencies it needs instead of making the class create them itself.

Without DI:

```text
StudentManager
      ↓
new StudentService()
```

With DI:

```text
StudentService
      ↓
StudentManager
```

The dependency is provided from outside.

---

# 13. DI Container

The DI Container manages dependencies.

Its job is to:

* Create required services
* Manage their lifetimes
* Provide them when another class needs them

Conceptually:

```text
DI Container
     ↓
StudentService
     ↓
StudentManager
```

---

# 14. Registering a Service

In ASP.NET Core, services can be registered with:

```csharp
builder.Services.AddTransient<StudentService>();
```

This tells the DI container:

> Register `StudentService` and create a new instance whenever it is requested.

---

# 15. Service Lifetimes

## Singleton

One instance is created for the application's lifetime.

```text
Application
    ↓
One StudentService instance
```

## Scoped

One instance is created for each request/scope.

```text
Request 1 → Instance A
Request 2 → Instance B
Request 3 → Instance C
```

## Transient

A new instance is created whenever the service is requested.

```text
Request → New instance
Request → New instance
Request → New instance
```

---

# 16. Important Difference

### Constructor Injection

The class receives its dependency through the constructor.

```csharp
public StudentManager(StudentService service)
{
    this.service = service;
}
```

### DI Container

The DI container is responsible for creating and providing that dependency.

```text
DI Container
      ↓
creates StudentService
      ↓
provides it to StudentManager
```

---

# 17. Practical Work

I created:

### `Student`

```csharp
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}
```

### `StudentService`

```csharp
class StudentService
{
    public string GetStudent()
    {
        Console.WriteLine("Getting Student..");
        return "";
    }
}
```

### `StudentManager`

I first created the service directly:

```csharp
StudentService service = new StudentService();
```

Then I changed it to constructor injection:

```csharp
public StudentManager(StudentService service)
{
    this.service = service;
}
```

This helped me understand why Dependency Injection is useful.

---

# 18. Mistakes / Things I Initially Found Difficult

* I initially did not understand why DI was needed.
* I confused constructor injection with the DI container.
* I initially thought changes inside `StudentService` automatically affect `StudentManager`.
* I was not sure how to write a controller. We postponed controllers because they are part of Day 6.
* I found it difficult to understand how the DI container creates and provides services.
* I understood the concept better after implementing constructor injection manually first.

---

# 19. Final Understanding

The most important concept I learned today:

> **Dependency Injection allows a class to receive its dependencies from outside instead of creating them itself.**

The complete flow:

```text
Application
    ↓
DI Container
    ↓
Creates StudentService
    ↓
Provides StudentService
    ↓
StudentManager
```

---

# 20. Day 5 Knowledge Check

### Question 1

What is Dependency Injection?

**My answer:**
It provides dependencies or services whenever needed.

### Question 2

Why is creating `StudentService` directly inside `StudentManager` a problem?

**My answer:**
Because `StudentManager` itself creates the service, which creates tight coupling.

### Question 3

What does this mean?

```csharp
builder.Services.AddTransient<StudentService>();
```

**My answer:**
It registers `StudentService` with the DI container and allows the container to provide it whenever needed.

### Question 4

What are Singleton, Scoped, and Transient?

**My answer:**

* Singleton → one instance for the entire application
* Scoped → one instance per request/scope
* Transient → new instance whenever requested

### Question 5

What is constructor injection?

**My answer:**
The dependency is provided through the constructor instead of being created inside the class.

---

# Day 5 Status

**🟢 COMPLETED**

### Learned

* Console vs Web Application
* Solution vs Project
* `.csproj`
* NuGet
* Application structure
* Models
* Services
* Configuration
* `appsettings.json`
* Environment settings
* Logging
* Dependencies
* Tight coupling
* Dependency Injection
* Constructor Injection
* DI Container
* Singleton
* Scoped
* Transient
* `AddTransient`

