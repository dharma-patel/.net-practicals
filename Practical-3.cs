using ExpenseTeacking;
using System;
using System.Collections.Generic;

namespace ExpenseTeacking
{
    public class Expense
    {
        public string Description;
        public decimal Amount;

        public Expense(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }
    }
    public class ExpenseTracker
    {
        private readonly decimal monthlyBudget;
        private readonly List<Expense> expenses;

        public ExpenseTracker(decimal budget)
        {
            if (budget <= 0)
                throw new ArgumentException("Budget must be greater than zero.");

            monthlyBudget = budget;
            expenses = new List<Expense>();
        }
        public void AddExpense(string description, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Expense description cannot be empty.");

            if (amount <= 0)
                throw new ArgumentException("Expense amount must be greater than zero.");

            decimal total = GetTotalExpenses();
            if (total + amount > monthlyBudget)
                throw new InvalidOperationException("Adding this expense exceeds the monthly budget.");

            expenses.Add(new Expense(description, amount));
            Console.WriteLine("Expense "+description+ " of "+amount+ " added successfully.");
        }
        public decimal GetTotalExpenses()
        {
            decimal totale = 0;
            foreach (var exp in expenses)
                totale += exp.Amount;
            return totale;
        }
        public void DisplayExpenses()
        {
            Console.WriteLine("\n--- Expense List ---");
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }

            foreach (var exp in expenses)
            Console.WriteLine(exp.Description+ " : " +exp.Amount);
            Console.WriteLine("Total Spent : " +GetTotalExpenses());
            decimal remaining = monthlyBudget - GetTotalExpenses();
            Console.WriteLine("Remaining Budget : "+remaining );
        }
    }
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter your monthly budget: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal budget))
                {
                    Console.WriteLine("Invalid budget input. Please enter a numeric value.");
                    return;
                }

                ExpenseTracker tracker = new ExpenseTracker(budget);

                while (true)
                {
                    Console.WriteLine("\n1. Add Expense");
                    Console.WriteLine("2. View Expenses");
                    Console.WriteLine("3. Exit");
                    Console.Write("Choose an option: ");

                    string choice = Console.ReadLine();
                    try
                    {
                        switch (choice)
                        {
                            case "1":
                                Console.Write("Enter expense description: ");
                                string desc = Console.ReadLine();

                                Console.Write("Enter expense amount: ");
                                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                                {
                                    Console.WriteLine("Invalid amount. Please enter a numeric value.");
                                    break;
                                }

                                tracker.AddExpense(desc, amount);
                                break;

                            case "2":
                                tracker.DisplayExpenses();
                                break;

                            case "3":
                                Console.WriteLine("Exiting program...");
                                return;

                            default:
                                Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Critical Error: {ex.Message}");
            }
        }
    }
}
