# .NET Core 15-Day Internship Challenge

> **Goal:** Learn and understand .NET Core, build a meaningful showcase project in 15 working days, document the learning journey, and become capable of using AI/LLMs to accelerate development without blindly accepting generated code.

## Internship Context

- **Start:** 24 September 2026
- **Duration of initial challenge:** 15 working days
- **Schedule:** 10:30 AM–2:00 PM, 2:45 PM–6:00 PM, 6:15 PM–7:30 PM
- **Work week:** 5 days/week
- **Primary technology:** .NET / ASP.NET Core
- **Later direction:** AI-assisted development using prompting and LLMs

## North-Star Outcome

By Day 15, this repository should demonstrate:

1. Understanding of C# and the .NET ecosystem
2. Understanding of ASP.NET Core and backend architecture
3. A working, non-trivial project that solves a real problem
4. Progressive feature development
5. Real debugging and problem-solving
6. Appropriate use of database, validation, error handling, testing, and Git
7. AI-assisted development where useful, with human review and understanding
8. Day-wise evidence of learning, mistakes, challenges, decisions, and interview preparation
9. A final project demo/presentation suitable for the company head

---

# 15-Day Roadmap

> The exact project will be selected after understanding the company requirements and the concepts learned. We will NOT force a generic CRUD project.

## Phase 1 — Understand .NET Core

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

### Day 03 — C# Collections + Modern C#
- Arrays
- List
- Dictionary
- HashSet
- Generics
- Lambda expressions
- Exception handling
- `async` / `await` introduction

**End test:** Collection/code-output problems + implementation task.

### Day 04 — LINQ + Async Thinking
- LINQ
- `Where`
- `Select`
- `OrderBy`
- `FirstOrDefault`
- `Any`
- `Count`
- Deferred execution basics
- Task / async / await

**Build:** Data-processing mini feature.

**End test:** LINQ problems + explain async flow.

### Day 05 — .NET Application Structure
- Console vs web application
- Solution vs project
- NuGet
- Configuration
- Environment settings
- Logging
- Dependency Injection fundamentals

**Build:** Small structured .NET application.

**End test:** Explain DI and project structure.

### Day 06 — ASP.NET Core Fundamentals
- HTTP
- Request/response
- REST
- Routing
- Controllers
- Actions
- HTTP verbs
- Status codes
- Swagger/OpenAPI

**Build:** First ASP.NET Core API.

**End test:** Explain complete request flow.

### Day 07 — API Architecture
- Controller vs Service
- DTOs
- Dependency Injection in ASP.NET Core
- Model binding
- Validation
- Middleware
- Global error handling basics

**Build:** Structured API with controller/service separation.

**End test:** Architecture/interview round.

---

# Phase 2 — Database + Project Foundation

### Day 08 — Database + Entity Framework Core
- Relational database concepts
- SQL basics
- Entity Framework Core
- DbContext
- DbSet
- Entities
- CRUD with EF Core
- Connection strings

**Build:** Persist API data.

**End test:** Explain EF Core and database flow.

### Day 09 — Relationships + Real Queries
- One-to-one
- One-to-many
- Many-to-many
- Foreign keys
- EF Core relationships
- Migrations
- LINQ database queries
- Search/filter/sort concepts

**Build:** Real relational feature.

**End test:** Database design + query challenge.

### Day 10 — Project Architecture + Security Foundation
- Finalize project problem
- Define entities and relationships
- Define API endpoints
- Project structure
- Authentication basics
- Authorization basics
- Password/security considerations
- Validation and error strategy

**Deliverable:** Project architecture + first working foundation.

**End test:** Defend architecture decisions.

---

# Phase 3 — Build + AI-Assisted Development

### Day 11 — Core Project Features
- Implement the highest-value feature set
- Apply controller/service/EF Core architecture
- Testing through Swagger/Postman
- Debug real issues

**Focus:** Build, don't tutorial-watch.

**End test:** Explain one complete feature from request to database.

### Day 12 — Advanced Features + Debugging
- Search/filter/sort or another meaningful feature
- Edge cases
- Exception handling
- Validation
- Performance/basic optimization
- Debugging workflow

**Challenge log:** Record a real bug and how it was solved.

**End test:** Debugging + technical interview.

### Day 13 — AI-Assisted Development
- Prompting for software development
- Requirement → prompt
- Generate → inspect → modify → test
- AI-generated code review
- Hallucination/error detection
- Security and quality checks
- Use AI to accelerate a real project feature

**AI log:** Prompt → generated approach → what was changed → why → test result.

**End test:** Explain AI-generated code without relying on the AI.

### Day 14 — Integration + Quality
- Complete remaining features
- Refactor
- Testing
- API documentation
- Error handling
- Clean code
- Git history cleanup
- README project documentation
- Presentation preparation

**End test:** Full project defense rehearsal.

### Day 15 — Final Review + Showcase
- Final bug fixing
- Final testing
- Git checkpoint
- Project documentation
- Architecture explanation
- Technical interview
- Project presentation
- Demo
- Lessons learned
- Future improvements

**Final output:**
- Working project
- GitHub repository
- Day-wise learning documentation
- AI usage documentation
- Challenge/mistake log
- Presentation-ready demo
- Technical/project-defense preparation

---

# Daily Operating System

Every working day follows:

**RECALL → LEARN → BUILD → DEBUG → TEST → DOCUMENT → INTERVIEW → GIT**

## 1. Day Objective
What must be understood today?

## 2. Learn
Concept + why it exists + connection to existing MERN/C++ knowledge.

## 3. Problem
What real problem are we solving?

## 4. Implement
Write the code ourselves. AI can assist later, but understanding remains mandatory.

## 5. Challenge
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
└── (code / screenshots / evidence where useful)
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
- Have a clear architecture
- Contain progressively deeper features
- Include real validation and error handling
- Use a database appropriately
- Have at least one feature that demonstrates thoughtful engineering
- Eventually include an appropriate AI/LLM-assisted capability if the company direction permits it

The project is the **proof of the learning**, not a substitute for learning.

---

# AI Development Rule

> **AI writes faster. I remain responsible for correctness.**

For AI-assisted features:

```text
Requirement
    ↓
Break into smaller tasks
    ↓
Write a precise prompt
    ↓
Generate/assist
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

Never accept code simply because it works once.

---

# Final Day-15 Presentation Structure

1. Problem
2. Why this problem matters
3. Solution
4. Architecture
5. Technology stack
6. Key features
7. Important technical decisions
8. One or more real challenges
9. How the challenges were solved
10. AI usage and human review
11. Live demo
12. What I learned
13. What I would improve next

---

# Progress Tracker

| Day | Topic | Code | Test | Docs | Git |
|---|---|---|---|---|---|
| 01 | .NET + C# Foundation | ✅ | ✅ | ✅ | ✅ |
| 02 | C# OOP | ✅ | ✅ | ✅ | ✅ |
| 03 | Collections + Modern C# | ✅ | ✅ | ✅ | ✅ |
| 04 | LINQ + Async | ⬜ | ⬜ | ⬜ | ⬜ |
| 05 | .NET Structure + DI | ⬜ | ⬜ | ⬜ | ⬜ |
| 06 | ASP.NET Core | ⬜ | ⬜ | ⬜ | ⬜ |
| 07 | API Architecture | ⬜ | ⬜ | ⬜ | ⬜ |
| 08 | EF Core + Database | ⬜ | ⬜ | ⬜ | ⬜ |
| 09 | Relationships + Queries | ⬜ | ⬜ | ⬜ | ⬜ |
| 10 | Architecture + Security | ⬜ | ⬜ | ⬜ | ⬜ |
| 11 | Core Project Features | ⬜ | ⬜ | ⬜ | ⬜ |
| 12 | Advanced Features + Debugging | ⬜ | ⬜ | ⬜ | ⬜ |
| 13 | AI-Assisted Development | ⬜ | ⬜ | ⬜ | ⬜ |
| 14 | Integration + Quality | ⬜ | ⬜ | ⬜ | ⬜ |
| 15 | Final Showcase | ⬜ | ⬜ | ⬜ | ⬜ |

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
- The roadmap can be corrected when actual internship requirements differ.
- Company requirements always take priority over this generic roadmap.
