using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge_withClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfContests = new List<Contest>();
            var dictStudentTotalPoints = new Dictionary<string, int>();
            string input;
            while ((input=Console.ReadLine())!="no more time")
            {              
                string[] inputArray = input.Split(" -> ");
                string student = inputArray[0];
                string contest = inputArray[1];
                int points = int.Parse(inputArray[2]);
                if (!listOfContests.Any(x => x.Name == contest))
                {
                    Contest newContest = new Contest(contest);
                    newContest.Name = contest;
                    newContest.StudentsWithPoints = new Dictionary<string, int>();
                    newContest.StudentsWithPoints.Add(student, points);
                    listOfContests.Add(newContest);
                    CheckIfdictStudentsTotalPointsContainsStudent(dictStudentTotalPoints, student, points);
                }

                else if (listOfContests.Any(x => x.Name == contest))
                {
                    Contest foundContest = listOfContests.First(x => x.Name == contest);
                    if (!foundContest.StudentsWithPoints.Any(x => x.Key == student))
                    {
                        foundContest.StudentsWithPoints.Add(student, points);
                        CheckIfdictStudentsTotalPointsContainsStudent(dictStudentTotalPoints, student, points);
                    }

                    else if (foundContest.StudentsWithPoints.Any(x => x.Key == student))
                    {
                        if (foundContest.StudentsWithPoints[student] < points)
                        {
                            int previousPoints = foundContest.StudentsWithPoints[student];
                            foundContest.StudentsWithPoints[student] = points;
                            if (!dictStudentTotalPoints.ContainsKey(student))
                            {
                                dictStudentTotalPoints[student] = points;
                            }

                            else
                            {
                                dictStudentTotalPoints[student] -= previousPoints;
                                dictStudentTotalPoints[student] += points;
                            }
                        }
                    }
                }
            }

            PrintContestsWithStudents(listOfContests);
            PrintUsersWithPoints(dictStudentTotalPoints);
        }


        private static void PrintUsersWithPoints(Dictionary<string, int> dictStudentTotalPoints)
        {
            Console.WriteLine("Individual standings:");
            int count = 1;
            foreach (var (student, totalPoints) in dictStudentTotalPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{count}. {student} -> {totalPoints}");
                count++;
            }
        }

        private static void PrintContestsWithStudents(List<Contest> listOfContests)
        {
            foreach (var contest in listOfContests)
            {
                Console.WriteLine($"{contest.Name}: {contest.StudentsWithPoints.Keys.Count()} participants");
                int firstCount = 1;
                foreach (var (student, points) in contest.StudentsWithPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{firstCount}. {student} <::> {points}");
                    firstCount++;
                }
            }
        }

        private static void CheckIfdictStudentsTotalPointsContainsStudent(Dictionary<string, int> dictStudentTotalPoints, string student, int points)
        {
            if (!dictStudentTotalPoints.ContainsKey(student))
            {
                dictStudentTotalPoints[student] = points;
            }

            else
            {
                dictStudentTotalPoints[student] += points;
            }
        }

        public class Contest
        {
            public string Name { get; set; }
            public Dictionary<string, int> StudentsWithPoints { get; set; }

            public Contest(string name)
            {
                this.Name = Name;
                this.StudentsWithPoints = new Dictionary<string, int>();
            }
        }
    }
}
