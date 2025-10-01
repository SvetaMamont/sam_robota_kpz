using System;
using System.Collections.Generic;


abstract class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }
    // Віртуальний метод для обчислення бонусу
    public abstract decimal CalculateBonus();
 
    public override string ToString()
    {
        return $"{Name}, Зарплата: {Salary:F0}, Бонус: {CalculateBonus():F2}";
    }
}
// Інтерфейс для звіту
interface IReportable
{
    void GenerateReport();
}
// Менеджер успадковує Employee і реалізує IReportable
class Manager : Employee, IReportable
{
    public Manager(string name, decimal salary) : base(name, salary) { }

    public override decimal CalculateBonus()
    {
        return Salary * 0.20m; // 20% від зарплати
    }

    public void GenerateReport()
    {
        Console.WriteLine($"Звіт менеджера {Name}: Контроль виконання завдань.");
    }
}

// Розробник успадковує Employee
class Developer : Employee
{
    public Developer(string name, decimal salary) : base(name, salary) { }
    public override decimal CalculateBonus()
    {
        return Salary * 0.10m; // 10% від зарплати
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Manager("Олена", 30000),
            new Developer("Іван", 25000),
            new Developer("Марія", 27000),
            new Manager("Петро", 35000)
        };

        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
            if (emp is IReportable reportable)
            {
                reportable.GenerateReport();
                Console.WriteLine();
            }
            
        }
    }
}