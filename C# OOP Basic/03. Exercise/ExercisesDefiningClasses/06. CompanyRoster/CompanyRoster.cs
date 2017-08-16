using System;
using System.Collections.Generic;
using System.Linq;

internal class CompanyRoster
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            string[] items = Console.ReadLine().Split();
            string name = items[0];
            decimal salary = decimal.Parse(items[1]);
            string position = items[2];
            string department = items[3];

            if (items.Length == 4)
            {
                employees.Add(new Employee(name, salary, position, department));
            }
            else if (items.Length == 5)
            {
                int temporaryItem;

                if (int.TryParse(items[4], out temporaryItem))
                {
                    employees.Add(new Employee(name, salary, position, department, temporaryItem));
                }
                else
                {
                    employees.Add(new Employee(name, salary, position, department, items[4]));
                }
            }
            else
            {
                string email = items[4];
                int age = int.Parse(items[5]);

                employees.Add(new Employee(name, salary, position, department, email, age));
            }
        }

        string higestAvarrageSalary = employees
        .GroupBy(employe => employe.Department, employe => employe.Salary)
            .OrderByDescending(employe => employe.Sum() / employe.Count())
            .First()
            .Key;

        List<Employee> sortedDepartment = employees
        .Where(departmen => departmen.Department == higestAvarrageSalary)
            .OrderByDescending(employe => employe.Salary)
            .ToList();

        Console.WriteLine($"Highest Average Salary: {higestAvarrageSalary}");
        Console.WriteLine(string.Join("\n", sortedDepartment));
    }
}