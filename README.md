# .NET Core 15-Day Internship Challenge

> **Goal:** Build strong .NET/C# fundamentals, independently build a complete full-stack CRUD/API application using ASP.NET Core + SQL Server + HTML/CSS/JavaScript, and then learn how to use LLMs to accelerate development after the fundamentals and independent implementation are strong.

## Internship Context

- **Start:** 24 September 2026
- **Duration of initial challenge:** 15 working days
- **Work week:** 5 days/week
- **Primary technology:** .NET / ASP.NET Core
- **Database:** SQL Server
- **Frontend:** HTML + CSS + JavaScript
- **Later direction:** AI-assisted development using prompting and LLMs
- **Important company direction:** First understand and build the application yourself. After the understanding is strong, use LLMs to accelerate development.

---

# North-Star Outcome

By Day 15, this repository should demonstrate:

1. Strong understanding of C# and the .NET ecosystem.
2. Understanding of ASP.NET Core and backend architecture.
3. Ability to build a REST API independently.
4. Ability to work with SQL Server and Entity Framework Core.
5. Ability to build a simple frontend using HTML, CSS and JavaScript.
6. Ability to connect frontend → API → database.
7. Real debugging and problem-solving without depending on AI.
8. Progressive feature development and clean project structure.
9. Ability to use LLMs effectively after understanding the underlying implementation.
10. Human review and understanding of all AI-assisted code.
11. Day-wise evidence of learning, mistakes, challenges, decisions and interview preparation.
12. A final working project suitable for demo and discussion with the company head.

---

# 15-Day Roadmap

> **Important change based on mentor/company direction:** Days 05–12 focus on understanding and independent implementation. LLM-assisted development starts only after the core application has been understood and built. Company requirements take priority over this roadmap.

---

## Phase 1 — .NET + C# Foundation

### Day 01 — .NET Ecosystem + C# Foundation

- What is .NET?
- What is C#?
- .NET SDK vs Runtime
- ASP.NET Core
- .NET CLI
- Project structure
- `.csproj`
- `Program.cs`
- C# types, variables, methods
- Classes and objects
- Connect concepts with C++ / JavaScript / Node.js
- Build a tiny console application

**End test:** Explain .NET, C#, SDK, Runtime and ASP.NET Core without notes.

---

### Day 02 — C# OOP

- Classes and objects
- Constructors
- Properties
- Access modifiers
- Encapsulation
- Inheritance
- Polymorphism
- Abstract classes
- Interfaces

**Build:** Small domain model.

**End test:** OOP interview + implementation challenge.

---

### Day 03 — C# Collections + Modern C#

- Arrays
- `List<T>`
- `Dictionary<TKey,TValue>`
- `HashSet<T>`
- Generics
- Lambda expressions
- Exception handling
- `async` / `await`
- `Task`
- `Task<T>`
- `Task.WhenAll()`

**Build:** Student data-processing mini project.

**End test:** Collection/code-output problems + async implementation task.

---

### Day 04 — LINQ + Async Thinking

- LINQ
- `Where`
- `Select`
- `OrderBy`
- `OrderByDescending`
- `FirstOrDefault`
- `Any`
- `Count`
- Deferred execution basics
- Task / async / await
- Concurrent asynchronous operations
- `Task.WhenAll()`

**Build:** Student Performance Analyzer.

**End test:** LINQ problems + explain async flow.

**Status:** Completed.

---

## Phase 2 — .NET Application + ASP.NET Core

### Day 05 — .NET Application Structure + Dependency Injection

- Console vs Web application
- Solution vs project
- `.sln`
- `.csproj`
- NuGet
- `appsettings.json`
- Configuration
- Environment settings
- Development vs Production
- Logging
- Dependency Injection
- Dependency vs Dependency Injection
- DI container
- Constructor injection
- `AddSingleton`
- `AddScoped`
- `AddTransient`

**Build:** Small structured .NET application using DI.

**LLM:** ❌ No LLM-generated implementation.

**End test:**
- Explain solution vs project.
- Explain NuGet.
- Explain configuration.
- Explain DI.
- Explain Singleton, Scoped and Transient.
- Explain the project structure.

---

### Day 06 — ASP.NET Core + HTTP + REST API

- What is ASP.NET Core?
- HTTP
- Request / response
- URL
- REST
- Routing
- Controllers
- Actions
- HTTP verbs
- GET
- POST
- PUT
- DELETE
- HTTP status codes
- Swagger/OpenAPI

**Build:** First ASP.NET Core API.

Example:

```text
GET    /api/students
GET    /api/students/{id}
POST   /api/students
PUT    /api/students/{id}
DELETE /api/students/{id}
```

**Testing:** Swagger + Postman.

**LLM:** ❌ No LLM-generated implementation.

**End test:** Explain complete HTTP request → ASP.NET Core → response flow.

---

### Day 07 — API Architecture

- Controller vs Service
- DTOs
- Dependency Injection in ASP.NET Core
- Model binding
- Validation
- Middleware
- Global error handling basics
- Separation of responsibilities

**Build:** Structured API with controller/service separation.

```text
Request
   ↓
Controller
   ↓
Service
   ↓
Response
```

**LLM:** ❌ No LLM-generated implementation.

**End test:** Architecture/interview round.

---

## Phase 3 — SQL Server + Entity Framework Core

### Day 08 — SQL Server + Entity Framework Core

### SQL Server

- Relational database concepts
- Database
- Table
- Row
- Column
- Primary key
- Foreign key
- `SELECT`
- `INSERT`
- `UPDATE`
- `DELETE`
- `WHERE`
- `ORDER BY`
- Basic JOIN

### Entity Framework Core

- What is ORM?
- Entity
- `DbContext`
- `DbSet`
- Connection strings
- CRUD with EF Core
- Migrations

**Build:** Persist API data in SQL Server.

```text
ASP.NET Core
      ↓
   EF Core
      ↓
 SQL Server
```

**LLM:** ❌ No LLM-generated implementation.

**End test:** Explain API → EF Core → SQL Server data flow.

---

### Day 09 — Relationships + Real Queries

- One-to-one
- One-to-many
- Many-to-many
- Foreign keys
- Navigation properties
- EF Core relationships
- Migrations
- LINQ database queries
- Search
- Filtering
- Sorting

**Build:** Real relational feature.

Example:

```text
Student
   │
   └── Enrollment
          │
          └── Course
```

**LLM:** ❌ No LLM-generated implementation.

**End test:**
- Database design challenge
- SQL query challenge
- LINQ query challenge
- Explain relationships

---

## Phase 4 — Project Design + Frontend

### Day 10 — Project Architecture + HTML/CSS/JavaScript Foundation

Now define the actual project to be built.

### Project planning

- Define the problem
- Define users/use cases
- Define features
- Define entities
- Define relationships
- Define database schema
- Define API endpoints
- Define frontend pages
- Define project/folder structure
- Define validation and error strategy

### Frontend

The frontend will use:

- HTML
- CSS
- JavaScript

There is no separate ".NET HTML" or ".NET CSS". HTML and CSS remain standard web technologies. JavaScript is used to interact with the API.

### HTML

- Page structure
- Forms
- Inputs
- Buttons
- Tables
- Basic validation

### CSS

- Box model
- Flexbox
- Grid
- Spacing
- Basic responsive layout
- Basic UI styling

### JavaScript

- Variables
- Functions
- DOM
- Events
- `fetch()`
- JSON
- GET/POST requests

**Deliverable:**

```text
Project problem
Features
Entities
Database design
API endpoint list
Frontend page list
Folder structure
```

**LLM:** ❌ No LLM-generated implementation.

**End test:** Defend the project architecture.

---

## Phase 5 — Independent Full-Stack Development

### Day 11 — Backend CRUD — Build Yourself

Build the core application independently.

Architecture:

```text
ASP.NET Core
      ↓
 Controller
      ↓
   Service
      ↓
   EF Core
      ↓
 SQL Server
```

Implement:

- Create
- Read
- Update
- Delete
- Validation
- Error handling
- Database persistence

**Testing:**

- Swagger
- Postman

**Rule:** You write the implementation yourself.

**Mentor role:** Explain concepts, ask questions, review code and provide hints. Do not depend on generated implementation.

**LLM:** ❌ Not used for implementation.

**End test:** Explain one complete feature from HTTP request → controller → service → EF Core → SQL Server → response.

---

### Day 12 — Frontend + API Integration

Connect the frontend to the backend.

```text
HTML
CSS
JavaScript
   ↓
fetch()
   ↓
ASP.NET Core API
   ↓
Controller
   ↓
Service
   ↓
EF Core
   ↓
SQL Server
```

Implement:

- Display data
- Create data
- Update data
- Delete data
- Basic frontend validation
- API error display
- Loading/error states

Example:

```text
HTML Form
    ↓
JavaScript fetch()
    ↓
POST /api/students
    ↓
ASP.NET Core
    ↓
SQL Server
```

**LLM:** ❌ No LLM-generated implementation.

**End test:** Build and explain one feature from frontend → API → database.

---

## Phase 6 — LLM-Assisted Development

> **Transition point:** The fundamentals and core application should now be understood and independently implemented. LLM use begins only after this point.

### Day 13 — LLM-Assisted Development

- Prompting for software development
- Requirement → prompt
- Break requirements into smaller tasks
- Generate → inspect → modify → test
- AI-generated code review
- Hallucination/error detection
- Security and quality checks
- Use AI to accelerate a real project feature

### AI workflow

```text
Requirement
    ↓
Understand the requirement
    ↓
Design the solution
    ↓
Write a precise prompt
    ↓
LLM generates/assists
    ↓
Read the code
    ↓
Understand the code
    ↓
Modify if necessary
    ↓
Test
    ↓
Debug
    ↓
Commit
```

**AI log:**

```text
Requirement:
My approach:
Prompt:
AI-generated approach:
What I changed:
Why I changed it:
Testing:
Result:
```

**Golden rule:**

> AI writes faster. I remain responsible for correctness.

**End test:** Explain AI-generated code without relying on the AI.

---

### Day 14 — AI + Integration + Quality

Use AI strategically for:

- Complete remaining features
- Search/filter/sort
- Pagination
- Validation
- Error handling
- Refactoring
- Test generation
- Code review
- Documentation
- Debugging assistance

**Quality work:**

- Clean code
- Naming
- Project structure
- Error handling
- Security basics
- API documentation
- README
- Git history cleanup

**Challenge:** Identify and fix at least one issue in AI-generated code.

**End test:** Debug an AI-assisted implementation and explain the fix.

---

### Day 15 — Final Project + Defense

Final application architecture:

```text
             FRONTEND
          HTML + CSS + JS
                 ↓
               HTTP
                 ↓
          ASP.NET CORE API
                 ↓
             CONTROLLER
                 ↓
               SERVICE
                 ↓
              EF CORE
                 ↓
             SQL SERVER
```

### Final work

- Final bug fixing
- Final testing
- Git checkpoint
- Project documentation
- Architecture explanation
- Technical interview
- Project presentation
- Live demo
- Lessons learned
- Future improvements

### Final outputs

- Working full-stack project
- GitHub repository
- Day-wise learning documentation
- AI usage documentation
- Challenge/mistake log
- README
- Presentation-ready demo
- Technical/project-defense preparation

---

# Daily Operating System

Every working day follows:

**RECALL → LEARN → BUILD → DEBUG → TEST → DOCUMENT → INTERVIEW → GIT**

## 1. Day Objective

What must be understood today?

## 2. Learn

Concept + why it exists + connection to existing C++ / JavaScript / MERN knowledge.

## 3. Problem

What real problem are we solving?

## 4. Implement

### Days 05–12

Write the code ourselves.

AI/LLM is not used to generate the implementation.

### Days 13–15

AI can assist after the problem and architecture are understood.

Understanding remains mandatory.

## 5. Challenge Log

Record:

- What went wrong?
- What did we expect?
- What actually happened?
- How did we investigate?
- What was the root cause?
- How did we fix it?
- What did we learn?

## 6. End-of-Day Test

Every day includes:

- Recall questions
- Concept questions
- Why/how questions
- Code/output questions
- Small implementation challenge
- Interview questions

## 7. Documentation

Each day should have:

```text
Day-X/

├── README.md
├── notes.md
├── mistakes.md
├── interview.md
└── code / screenshots / evidence where useful
```

For Days 13–15, also maintain:

```text
AI-log.md
```

## 8. Git Checkpoint

Every day:

```bash
git status
git add .
git commit -m "..."
git push
```

Commit messages should describe the actual milestone.

---

# Project Philosophy

The project should NOT be:

- A tutorial clone
- A basic Todo CRUD
- A generic Student Management System
- A collection of copied AI-generated code

The project SHOULD:

- Solve a meaningful problem
- Demonstrate .NET learning
- Use ASP.NET Core
- Use SQL Server
- Have a clear architecture
- Have an HTML/CSS/JavaScript frontend
- Demonstrate frontend → API → database integration
- Contain progressively deeper features
- Include real validation and error handling
- Use a database appropriately
- Have at least one feature that demonstrates thoughtful engineering
- Use LLMs only after the fundamentals and independent implementation are understood

> **The project is the proof of the learning, not a substitute for learning.**

---

# AI Development Rule

> **AI writes faster. I remain responsible for correctness.**

The AI phase follows:

```text
Requirement
    ↓
Understand
    ↓
Design
    ↓
Break into smaller tasks
    ↓
Write precise prompt
    ↓
Generate / assist
    ↓
Read code
    ↓
Understand code
    ↓
Modify if necessary
    ↓
Test
    ↓
Debug
    ↓
Commit
```

Never accept code simply because it works once.

If you cannot explain:

- What the code does
- Why it was written that way
- What its dependencies are
- What can go wrong
- How it interacts with the rest of the application

then you do not yet own the code.

---

# Final Day-15 Presentation Structure

1. Problem
2. Why this problem matters
3. Solution
4. Architecture
5. Technology stack
6. Frontend flow
7. Backend/API flow
8. Database design
9. Key features
10. Important technical decisions
11. One or more real challenges
12. How the challenges were solved
13. AI usage and human review
14. Live demo
15. What I learned
16. What I would improve next

---

# Progress Tracker

| Day | Topic | Code | Test | Docs | Git |
|---|---|---|---|---|---|
| 01 | .NET + C# Foundation | ✅ | ✅ | ✅ | ✅ |
| 02 | C# OOP | ✅ | ✅ | ✅ | ✅ |
| 03 | Collections + Modern C# | ✅ | ✅ | ✅ | ✅ |
| 04 | LINQ + Async | ✅ | ✅ | ✅ | ✅ |
| 05 | .NET Structure + DI | ⬜ | ⬜ | ⬜ | ⬜ |
| 06 | ASP.NET Core + REST API | ⬜ | ⬜ | ⬜ | ⬜ |
| 07 | API Architecture | ⬜ | ⬜ | ⬜ | ⬜ |
| 08 | SQL Server + EF Core | ⬜ | ⬜ | ⬜ | ⬜ |
| 09 | Relationships + Queries | ⬜ | ⬜ | ⬜ | ⬜ |
| 10 | Project Architecture + Frontend Foundation | ⬜ | ⬜ | ⬜ | ⬜ |
| 11 | Backend CRUD — Independent | ⬜ | ⬜ | ⬜ | ⬜ |
| 12 | Frontend + API Integration — Independent | ⬜ | ⬜ | ⬜ | ⬜ |
| 13 | LLM-Assisted Development | ⬜ | ⬜ | ⬜ | ⬜ |
| 14 | AI + Integration + Quality | ⬜ | ⬜ | ⬜ | ⬜ |
| 15 | Final Project + Defense | ⬜ | ⬜ | ⬜ | ⬜ |

---

# Mentor Rules

- Do not blindly copy code.
- Understand before moving forward.
- Ask "why?" for important decisions.
- Prefer official documentation for verification.
- Record mistakes instead of hiding them.
- Build incrementally.
- Test every meaningful feature.
- Commit every day.
- Keep the project realistic and finishable.
- During Days 05–12, prioritize independent implementation.
- After understanding is strong, use LLMs to accelerate development.
- Review every AI-generated change.
- Never depend on AI to explain code you have not understood.
- The roadmap can be corrected when actual internship requirements differ.
- **Company requirements always take priority over this roadmap.**
