using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var listOfStudents = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                var inputArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArray[0];
                int age = int.Parse(inputArray[1]);
                Student newStudent = new Student(name, age);
                listOfStudents.Add(newStudent);
            }

            string firstCondition = Console.ReadLine();
            int secondCondition = int.Parse(Console.ReadLine());
            string[] pairs = Console.ReadLine().Split();
            Func<int, bool> func = null;
            if (firstCondition == "older")
            {
                func = x => x >= secondCondition;
            }

            else if (firstCondition == "younger")
            {
                func = x => x < secondCondition;
            }

            var filtertedList = listOfStudents.Where(x => func(x.Age));
            if (pairs.Contains("name") && pairs.Contains("age"))
            {
                foreach (var student in filtertedList)
                {
                    Console.WriteLine($"{student.Name} - { student.Age}");
                }
            }

            else if (pairs.Contains("name"))
            {
                foreach (var student in filtertedList)
                {
                    Console.WriteLine(student.Name);
                }
            }

            else if (pairs.Contains("age"))
            {
                foreach (var student in filtertedList)
                {
                    Console.WriteLine(student.Age);
                }
            }
        }
    }


    class Student
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }
}
