using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictDepartmentEmployees = new Dictionary<string, List<Employee>>();
            int linesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesNumber; i++)
            {
                string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArray[0];
                decimal salary = decimal.Parse(inputArray[1]);
                string department = inputArray[2];
                var newEmployee = new Employee(name, salary, department);
                if (!dictDepartmentEmployees.ContainsKey(department))
                {
                    dictDepartmentEmployees[department] = new List<Employee>();
                    dictDepartmentEmployees[department].Add(newEmployee);
                }

                else
                {
                    dictDepartmentEmployees[department].Add(newEmployee);
                }
            }

            string bestDepartment = FindBestDepartment(dictDepartmentEmployees);
            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            var listWithEmployees = dictDepartmentEmployees.Where(d => d.Key == bestDepartment).Select(d => d.Value).FirstOrDefault();
            foreach (var employee in listWithEmployees.OrderByDescending(e=>e.Salary))
            {
                Console.Write($"{employee.Name} ");
                Console.WriteLine($"{employee.Salary:F2}");
            }
        }


        private static string FindBestDepartment(Dictionary<string, List<Employee>> dictDepartmentEmployees)
        {
            decimal maxAverageSalary = 0;
            string bestDepartment = string.Empty;
            foreach (var (currentDepartment, employees) in dictDepartmentEmployees)
            {
                if (employees.Count > 0)
                {
                    decimal currentSumOfTheSalaries = 0;
                    foreach (var employee in employees)
                    {
                        currentSumOfTheSalaries += employee.Salary;
                    }

                    decimal currentAverageSalary = currentSumOfTheSalaries / employees.Count();
                    if (currentAverageSalary > maxAverageSalary)
                    {
                        maxAverageSalary = currentAverageSalary;
                        bestDepartment = currentDepartment;
                    }
                }
            }

            return bestDepartment;
        }
    }


    public class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}
