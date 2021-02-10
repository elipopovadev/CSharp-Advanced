using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfStudents = new List<Student>();
            int numberOfStudents = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = inputArray[0];
                string lastName = inputArray[1];
                double grade = double.Parse(inputArray[2]);
                var newStudent = new Student(firstName, lastName, grade);
                listOfStudents.Add(newStudent);
            }

            foreach (var student in listOfStudents.OrderByDescending(s=>s.Grade))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }


    class Student
    {
        public Student(string firstName, string lastName,double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.FirstName);
            sb.Append(" ");
            sb.Append(this.LastName);
            sb.Append(": ");
            sb.Append(this.Grade.ToString("N2")); // rounded
            return sb.ToString();
        }
    }
}
