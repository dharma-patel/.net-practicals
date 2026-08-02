using System;

namespace EmployeePayroll
{
    public class Employee
    {
        public int EmpId;
        public string EmpName;
        public double BaseSalary;
        public double NetSalary;

        public void AcceptDetails()
        {
            Console.Write("Enter ID: ");
            EmpId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            EmpName = Console.ReadLine();
            Console.Write("Enter Base Salary: ");
            BaseSalary = Convert.ToDouble(Console.ReadLine());
        }

        public void DisplayDetails()
        {
            Console.WriteLine("" + EmpName + " (" + EmpId + ") -> Net Salary: " + NetSalary);
        }
    }

    public class FullTimeEmployee : Employee
    {
        public void CalculateSalary()
        {
            NetSalary = BaseSalary + (BaseSalary * 0.20) + (BaseSalary * 0.10);
        }
    }

    public class PartTimeEmployee : Employee
    {
        public int Worked;
        public void CalculateSalary()
        {
            Console.Write("Enter Hours Worked: ");
            Worked = Convert.ToInt32(Console.ReadLine());
            NetSalary = BaseSalary * Worked;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Select Type (1. Full-Time, 2. Part-Time): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            var ft = new EmployeePayroll.FullTimeEmployee();
            ft.AcceptDetails();
            ft.CalculateSalary();
            ft.DisplayDetails();
        }
        else if (choice == 2)
        {
            var pt = new EmployeePayroll.PartTimeEmployee();
            pt.AcceptDetails();
            pt.CalculateSalary();
            pt.DisplayDetails();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
        Console.ReadKey();
    }
}
