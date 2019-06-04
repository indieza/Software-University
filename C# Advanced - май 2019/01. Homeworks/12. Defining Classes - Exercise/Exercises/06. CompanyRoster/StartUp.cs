namespace _06.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employes = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                double salary = double.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                string email = input.Length > 4 ? input[4].Contains("@") ? input[4] : "n/a" : "n/a";
                int age = input.Length > 4 ? !input[4].Contains("@") ? int.Parse(input[4]) : -1 : -1;
                age = input.Length > 5 ? int.Parse(input[5]) : age;

                Employee employee = new Employee(name, salary, position, department, email, age);
                employes.Add(employee);
            }

            string departmentWithHighAverageSalary = employes.GroupBy(x => x.Department)
                .OrderByDescending(y => y.Select(s => s.Salary).Average())
                .FirstOrDefault()
                .Key;

            Console.WriteLine($"Highest Average Salary: {departmentWithHighAverageSalary}");

            foreach (var employee in employes.Where(x => x.Department == departmentWithHighAverageSalary).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}