using System;
// class BankAccount
// {
//     public string AccountHolder{get; private set;}
//     public double Balance{get; private set;}

//     public BankAccount(string name, double amount)
//     {   if(!string.IsNullOrWhiteSpace(name))
//         {
//             this.AccountHolder = name;
//         }
//         else
//         {
//             Console.WriteLine("Account holder name is required.");
//         }
//         if(amount > 0) this.Balance = amount;
//         else
//         {   Console.WriteLine("Account balance never be negative. so intialize with zero as balance account.");
//           this.Balance = 0;

//         } 
//     }

//     public void Deposit(double amount)
//     {
//         if (amount <= 0)
//         {   
//             Console.WriteLine("Invalid Amount");
//             return;
//         }

//         Balance+=amount;
//         Console.WriteLine($"Deposit Successful, your Balance is: {Balance}");

//     }

//     public void Withdraw(double amount)
//     {   
//         if(amount > 0 && amount <= Balance)
//         {
//             Balance-=amount;
//             Console.WriteLine($"Withdraw Successful, your Balance is: {Balance}");
//             return;
//         }

//         Console.WriteLine("Invalid Amount");



//     }

//     public void DisplayAccount()
//     {
//         Console.WriteLine($"Hi, {AccountHolder}. your current account balance is {Balance}.");
//     }

//     public abstract double CalculateInterest();

// }

// class SavingsAccount : BankAccount
// {
//     public double InterestRate{get; set;}

//     public SavingsAccount(string name, double amount, double interest) : base(name, amount)
//     {
//         this.InterestRate = interest;
//     }
//     public override double CalculateInterest()
//     {
//         return Balance*(InterestRate/100);
//     }
// }

// class CurrentAccount : BankAccount
// {
//     public CurrentAccount(string name, double amount) : base(name, amount)
//     {

//     }

//     public override double CalculateInterest()
//     {
//         return 0;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         BankAccount acc1 = new SavingsAccount("Jay", 5000, 5);
//         BankAccount acc2 = new CurrentAccount("Rahul", 10000);

//         Console.WriteLine(acc1.CalculateInterest());
//         Console.WriteLine(acc2.CalculateInterest());

//     }
// }

abstract class Employee
{
    public string Name { get; private set; }
    public double Salary { get; private set; }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public abstract void DisplayInfo();
}

class Developer : Employee
{
    public string ProgrammingLanguage { get; set; }
    public Address Address { get; set; }

    public Developer(
        string name,
        double salary,
        string progLang,
        Address address) : base(name, salary)
    {
        ProgrammingLanguage = progLang;
        Address = address;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(
            $"Employee: {Name}, Salary: {Salary}, " +
            $"Programming: {ProgrammingLanguage}, " +
            $"City: {Address.City}"
        );
    }
}

class Manager : Employee
{
    public int TeamSize { get; set; }

    public Manager(string name, double salary, int teamSize)
        : base(name, salary)
    {
        TeamSize = teamSize;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(
            $"Employee: {Name}, Salary: {Salary}, " +
            $"Team Size: {TeamSize}"
        );
    }
}

class Address
{
    public string City { get; set; }
    public string Country { get; set; }
}
class Program
{
    static void Main()
    {
        Address address = new Address
        {
            City = "Indore",
            Country = "India"
        };

        Employee emp1 =
            new Developer("Jay", 50000, "C#", address);

        Employee emp2 =
            new Manager("Rahul", 50000, 5);

        emp1.DisplayInfo();
        emp2.DisplayInfo();

    }
}