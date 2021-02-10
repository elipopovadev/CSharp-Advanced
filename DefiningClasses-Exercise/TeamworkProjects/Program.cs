using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamworkProjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listWithCreators = new List<CreaterOnTeam>();
            int countOfTheTeams = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfTheTeams; i++)
            {
                string[] inputArray = Console.ReadLine().Split("-",StringSplitOptions.RemoveEmptyEntries);
                string creatorName = inputArray[0];
                string teamName = inputArray[1];
                if (!listWithCreators.Any(c => c.CreatorName == creatorName) && !listWithCreators.Any(c => c.TeamName == teamName))
                {
                    var newCreatorOnTeam = new CreaterOnTeam(creatorName, teamName);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                    listWithCreators.Add(newCreatorOnTeam);
                }

                else if (listWithCreators.Any(c => c.CreatorName == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }

                else if (listWithCreators.Any(c => c.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] inputArray = command.Split("->",StringSplitOptions.RemoveEmptyEntries);
                string userName = inputArray[0];
                string teamName = inputArray[1];
                if (!listWithCreators.Any(c => c.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

                else if (listWithCreators.Any(c => c.CreatorName == userName))
                {
                    Console.WriteLine($"Member {userName} cannot join team { teamName}!");

                }

                else if (listWithCreators.Any(c => c.Members.Contains(userName)))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                }

                else 
                {
                    var findCreator = listWithCreators.First(c => c.TeamName == teamName);
                    findCreator.AddUser(userName);
                }
            }

            FinalPrint(listWithCreators);
        }


        private static void FinalPrint(List<CreaterOnTeam> listWithCreators)
        {
            var listWithCreatorWithMembers = listWithCreators.Where(c => c.Members.Count != 0);
            foreach (var creatorOnTeam in listWithCreatorWithMembers.OrderByDescending(c => c.Members.Count).ThenBy(c=>c.TeamName))
            {
                Console.WriteLine(creatorOnTeam.ToString());
            }

            Console.WriteLine("Teams to disband:");
            var listWithCreatorWithoutMembers = listWithCreators.Where(c => c.Members.Count == 0);
            foreach (var creatorOnTeam in listWithCreatorWithoutMembers.OrderBy(c => c.TeamName))
            {
                Console.WriteLine(creatorOnTeam.TeamName);
            }
        }
    }


    public class CreaterOnTeam
    {
        public CreaterOnTeam(string creatorName, string teamName)
        {
            this.CreatorName = creatorName;
            this.TeamName = teamName;
            this.Members = new List<string>();
        }

        public string CreatorName { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public void AddUser(string userName)
        {
            this.Members.Add(userName);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.TeamName);
            sb.AppendLine($"- {this.CreatorName}");
            foreach (var userName in this.Members.OrderBy(u => u))
            {
                sb.AppendLine($"-- {userName}");
            }

            return sb.ToString().Trim();
        }
    }
}
