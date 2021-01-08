using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictContestPassword = new Dictionary<string, string>();
            var listWithStudents = new List<Student>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputArray = input.Split(":");
                string contest = inputArray[0];
                string password = inputArray[1];
                if (!dictContestPassword.ContainsKey(contest))
                {
                    dictContestPassword.Add(contest, password);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] inputArray = input.Split("=>");
                string contest = inputArray[0];
                string password = inputArray[1];
                string student = inputArray[2];
                int points = int.Parse(inputArray[3]);
                if (!dictContestPassword.ContainsKey(contest) || dictContestPassword[contest] != password)
                {
                    continue;
                }

                if (!listWithStudents.Any(x => x.Name == student))
                {
                    var newStudent = new Student(student);
                    newStudent.Name = student;
                    newStudent.ContestsWithPoints = new Dictionary<string, int>();
                    newStudent.ContestsWithPoints.Add(contest, points);
                    listWithStudents.Add(newStudent);
                }

                else if (listWithStudents.Any(x => x.Name == student))
                {
                    var findTheStudent = listWithStudents.First(x => x.Name == student);
                    if (!findTheStudent.ContestsWithPoints.Any(x => x.Key == contest))
                    {
                        findTheStudent.ContestsWithPoints.Add(contest, points);
                    }

                    else
                    {
                        if (findTheStudent.ContestsWithPoints[contest] < points)
                        {
                            findTheStudent.ContestsWithPoints[contest] = points;
                        }
                    }
                }


            }

            PrintTheRanking(listWithStudents);
        }


        public class Student
        {
            public string Name { get; set; }
            public Dictionary<string, int> ContestsWithPoints { get; set; }

            public Student(string name)
            {
                this.Name = name;
                this.ContestsWithPoints = new Dictionary<string, int>();
            }
        }

        private static void PrintTheRanking(List<Student> listWithStudents)
        {
            var bestCandidate = listWithStudents.OrderByDescending(x => x.ContestsWithPoints.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {bestCandidate.Name} with total {bestCandidate.ContestsWithPoints.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in listWithStudents.OrderBy(x => x.Name))
            {
                Console.WriteLine(student.Name);
                foreach (var (contest, points) in student.ContestsWithPoints.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
