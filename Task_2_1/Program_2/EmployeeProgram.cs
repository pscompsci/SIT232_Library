using System;

namespace Program_2
{
    class EmployeeProgram
    {
        static void Main(string[] args)
        {
            // Create two employees with different salaries
            Employee andrew = new Employee("Andrew Cain", 180000);
            Employee jane = new Employee("Jane Doe", 45000);

            // Test getting the name and salary
            Console.WriteLine("Employee Name: " + andrew.getName() +
                ", Salary: " + andrew.getSalary());
            Console.WriteLine("Employee Name: " + jane.getName() +
                ", Salary: " + jane.getSalary());

            // Test increasing the salary
            andrew.raiseSalary(5.0);  // expect $189000
            jane.raiseSalary(15.0);   // expect $51750

            Console.WriteLine();

            // Create additional employee in lowest tax bracket
            Employee trev = new Employee("Trev", 12300);
            Console.WriteLine("Employee Name: " + trev.getName() +
                ", Salary: " + trev.getSalary());

            // Test tax calculates correctly
            Console.WriteLine("Employee Name: " + andrew.getName() +
                ", Tax Burden: " + andrew.Tax()); // expect $58146
            Console.WriteLine("Employee Name: " + jane.getName() +
                ", Tax Burden: " + jane.Tax()); // expect $8365.75
            Console.WriteLine("Employee Name: " + trev.getName() +
                ", Tax Burden: " + trev.Tax()); // expect Nil tax

        }
    }
}
