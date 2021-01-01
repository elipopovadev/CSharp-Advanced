using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    static class Program
    {
        static void Main(string[] args)
        {

            int numberOfStudents = int.Parse(Console.ReadLine());
            var dictStudentGrades = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!dictStudentGrades.ContainsKey(name))
                {
                    dictStudentGrades[name] = new List<decimal>();
                    dictStudentGrades[name].Add(grade);
                }

                else
                {
                    dictStudentGrades[name].Add(grade);
                }
            }

            foreach (var (student, grades) in dictStudentGrades)
            {
                string allGrades= string.Join(" ", grades.Select(grade=> grade.ToString("F2"))); 
                decimal averageGrade = grades.Count > 0 ? grades.Average() : 0; // for Average every time you must check if count > 0
                Console.WriteLine($"{student} -> {allGrades} (avg: {averageGrade:F2})");
            }
        }
    }
}
