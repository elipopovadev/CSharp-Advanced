using System;
using System.Collections.Generic;
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
            string formatToPrint = Console.ReadLine();

            Func<Student, bool> predicate = null;
            if (firstCondition == "older")
            {
                predicate = s => s.Age >= secondCondition;
            }

            else if (firstCondition == "younger")
            {
                predicate = s => s.Age < secondCondition;
            }

            var filtertedList = listOfStudents.Where(predicate);

            foreach (var student in filtertedList)
            {
                switch (formatToPrint)
                {
                    case "name age":
                        {
                            Console.WriteLine($"{student.Name} - { student.Age}");
                            break;
                        }

                    case "name":
                        {
                            Console.WriteLine(student.Name);
                            break;
                        }

                    case "age":
                        {
                            Console.WriteLine(student.Age);
                            break;
                        }

                    default:
                        break;                     
                }
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

