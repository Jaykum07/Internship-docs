# Day 02 — OOP Fundamentals in C#

## Objective

Understand and practically apply core Object-Oriented Programming concepts in C# using real-world examples, especially a banking system.

## 1. What I Learned

### OOP

OOP organizes complex software around objects containing related state and behavior.

Example: instead of manually managing thousands of bank accounts, create a `BankAccount` class and many account objects.

### Class vs Object

- **Class:** Blueprint defining state and behavior.
- **Object:** Actual instance of a class.

## 2. Encapsulation

Encapsulation controls access to an object's internal state.

```csharp
public double Balance { get; private set; }
```

Outside code can read `Balance` but cannot directly modify it. Changes happen through controlled methods such as `Deposit()` and `Withdraw()`.

**Business rule:** a banking balance should not be directly changed because that could create invalid states such as a negative balance.

## 3. Fields vs Properties

- **Field:** Storage location inside a class.
- **Property:** Controlled access to data.

Example:

```csharp
public string Name { get; private set; }
```

## 4. Access Modifiers

- `public` → accessible from outside.
- `private` → accessible only inside the class.
- `protected` → accessible inside the class and derived classes.

Design lesson: use the minimum access required.

## 5. Inheritance

Inheritance allows a derived class to reuse and extend accessible members of a base class.

It represents an **IS-A** relationship.

```text
BankAccount
     ↓
SavingsAccount
```

## 6. Types of Inheritance

### Single

```text
A
↓
B
```

### Multilevel

```text
A
↓
B
↓
C
```

Example: `Employee → Developer → SeniorDeveloper`

### Hierarchical

```text
        Employee
        /      \
 Developer    Manager
```

### Multiple

C# does **not** support multiple inheritance through classes:

```csharp
class C : A, B { } // ❌
```

C# supports multiple interfaces:

```csharp
class Report : IPrintable, ISavable { }
```

### Hybrid

A combination of inheritance structures. C# can model complex designs using classes and interfaces rather than multiple class inheritance.

## 7. Polymorphism

Polymorphism allows the same method call to behave differently depending on the actual object.

```csharp
Employee emp1 = new Developer(...);
Employee emp2 = new Manager(...);

emp1.DisplayInfo();
emp2.DisplayInfo();
```

Both references are `Employee`, but the actual objects determine which overridden implementation runs.

## 8. Method Overloading

Same method name with different parameter lists.

```csharp
void Add(int a, int b) { }
void Add(double a, double b) { }
void Add(int a, int b, int c) { }
```

Commonly called compile-time polymorphism.

## 9. Method Overriding

A derived class provides a different implementation of a `virtual` or `abstract` method.

```csharp
class BankAccount
{
    public virtual double CalculateInterest()
    {
        return 0;
    }
}
```

```csharp
class SavingsAccount : BankAccount
{
    public override double CalculateInterest()
    {
        return Balance * (InterestRate / 100);
    }
}
```

### Key distinction

```text
Overloading
→ same name
→ different parameters
→ compile time

Overriding
→ same name
→ same parameters
→ different implementation
→ runtime
```

## 10. Abstraction

Abstraction hides unnecessary implementation details and exposes essential behavior.

```csharp
abstract class BankAccount
{
    public abstract double CalculateInterest();
}
```

An abstract class cannot be directly instantiated.

An abstract class can contain properties, fields, constructors, normal methods, and abstract methods.

An abstract method has no implementation:

```csharp
public abstract double CalculateInterest();
```

## 11. Abstraction vs Encapsulation

**Abstraction:** What should the object expose? It hides unnecessary complexity.

**Encapsulation:** How do we control/protect the object's internal state?

Easy memory rule:

```text
Abstraction
→ Hide unnecessary complexity
→ Expose essential behavior

Encapsulation
→ Control access to internal state
→ Protect business rules
```

## 12. Composition vs Inheritance

```text
IS-A  → Inheritance
HAS-A → Composition/Association
```

Examples:

```text
Developer IS-A Employee
SavingsAccount IS-A BankAccount
```

But:

```text
Developer HAS-A Address
Car HAS-A Engine
Company HAS-A Department
```

Example:

```csharp
class Developer
{
    public Address Address { get; set; }
}
```

Design lesson:

> Do not use inheritance simply to reuse code. First ask whether the relationship is genuinely IS-A.

# 13. Main OOP Challenge

Built a Developer Management System:

```text
Employee (abstract)
       │
       ├── Developer
       │      └── HAS-A → Address
       │
       └── Manager
```

It demonstrated:

- Abstraction
- Inheritance
- Encapsulation
- Composition
- Runtime polymorphism
- Method overriding

Key implementation:

```csharp
Employee emp1 =
    new Developer("Jay", 50000, "C#", address);

Employee emp2 =
    new Manager("Rahul", 50000, 5);

emp1.DisplayInfo();
emp2.DisplayInfo();
```

## 14. Mistakes I Made

### Mistake 1 — Abstract method with a body

Incorrect:

```csharp
public abstract double CalculateInterest()
{
}
```

Correct:

```csharp
public abstract double CalculateInterest();
```

**Lesson:** an abstract method defines a contract but has no implementation.

### Mistake 2 — Missing return type

Incorrect:

```csharp
public override DisplayInfo()
```

Correct:

```csharp
public override void DisplayInfo()
```

### Mistake 3 — Case sensitivity

Used `name` when the property was `Name`.

C# is case-sensitive.

### Mistake 4 — Printing a void method

Incorrect:

```csharp
Console.WriteLine(emp1.DisplayInfo());
```

Correct:

```csharp
emp1.DisplayInfo();
```

### Mistake 5 — Confusing overloading with inheritance

Correct understanding:

```text
Overloading
→ same method name + different parameter list

Inheritance
→ derived class inherits accessible members from base class
```

### Mistake 6 — Virtual vs abstract

```text
virtual
→ base class provides implementation
→ derived class MAY override

abstract
→ base class defines only a contract
→ concrete derived class MUST implement
```

### Mistake 7 — `protected set` vs `private set`

I initially used:

```csharp
public double Balance { get; protected set; }
```

This allows derived classes to modify `Balance`.

For stronger encapsulation:

```csharp
public double Balance { get; private set; }
```

## 15. Interview Revision

### What is OOP?

OOP is a programming approach that organizes software around objects containing related state and behavior.

### What is encapsulation?

Encapsulation controls access to an object's internal state and protects business rules from uncontrolled modification.

### What is inheritance?

Inheritance allows a derived class to reuse and extend accessible members of a base class and represents an IS-A relationship.

### What is polymorphism?

Polymorphism allows the same method call to behave differently depending on the actual object.

### What is abstraction?

Abstraction exposes essential behavior while hiding unnecessary implementation details.

### Overloading vs Overriding?

```text
Overloading:
same name + different parameters

Overriding:
same signature + different implementation in derived class
```

### Composition vs inheritance?

```text
IS-A  → inheritance
HAS-A → composition
```

## 16. Day 2 End-Test Result

**Conceptual result: 9/10**

Strong areas:

- OOP fundamentals
- Encapsulation
- Properties
- Inheritance
- Polymorphism
- Abstraction
- Composition
- Practical C# implementation

Areas to improve:

- Interview wording
- Multiple inheritance reasoning
- More precise terminology around inheritance and overriding

## 17. Revision for Day 3

Remember:

```text
Class
↓
Object
↓
Encapsulation
↓
Inheritance
↓
Polymorphism
↓
Abstraction
↓
Composition
```

Important mental models:

```text
IS-A  → Inheritance
HAS-A → Composition

virtual
→ can override

abstract
→ must implement

private set
→ outside code cannot modify

Employee reference
+
Developer object
→ runtime polymorphism
```

## 18. Real-World Lesson

> OOP is not about putting everything into classes. It is about choosing the right relationships and controlling how objects interact.

When designing a system, ask:

1. What is the state?
2. What is the behavior?
3. What should be private?
4. What is an IS-A relationship?
5. What is a HAS-A relationship?
6. Which behavior should vary?
7. What should be exposed to the outside world?

---

# Day 2 Status

**COMPLETED ✅**

- Learning → ✅
- Coding practice → ✅
- OOP challenge → ✅
- End test → ✅
- Interview revision → ✅
- Mistakes documented → ✅
- Revision points → ✅
