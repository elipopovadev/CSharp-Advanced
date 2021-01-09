using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfVloggers = new List<Vlogger>();
            string input;
            while ((input=Console.ReadLine())!="Statistics")
            {
                string[] inputArray = input.Split();
                if (inputArray[1] == "joined")
                {
                    string name = inputArray[0];
                    var newVlogger = new Vlogger(name);
                    if (listOfVloggers.Any(x => x.Name == name))
                    {
                        continue;
                    }

                    listOfVloggers.Add(newVlogger);
                    newVlogger.Name = name;
                    newVlogger.Followers = new HashSet<string>();
                    newVlogger.Following = new HashSet<string>();
                }

                else if (inputArray[1] == "followed")
                {
                    var firstVlogger = inputArray[0];
                    var secondVlogger = inputArray[2];
                    if (firstVlogger == secondVlogger) continue;
                    if (listOfVloggers.Any(x => x.Name == firstVlogger) && listOfVloggers.Any(x => x.Name == secondVlogger))
                    {
                        Vlogger findFirsVlogger = listOfVloggers.First(v => v.Name == firstVlogger);
                        findFirsVlogger.AddFollowing(secondVlogger);
                        Vlogger findSecondVlogger = listOfVloggers.First(v => v.Name == secondVlogger);
                        findSecondVlogger.AddFollower(firstVlogger);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {listOfVloggers.Count} vloggers in its logs.");
            var famousVlogger = listOfVloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count).First();
            if (famousVlogger.Followers.Count > 0)
            {
                Console.WriteLine($"1. {famousVlogger.Name} : {famousVlogger.Followers.Count} followers, {famousVlogger.Following.Count} following");
                foreach (var follower in famousVlogger.Followers.OrderBy(x => x))
                {
                    Console.WriteLine($"*  {follower}");
                }

                listOfVloggers.Remove(famousVlogger);
                int count = 2;
                foreach (var vlogger in listOfVloggers.OrderByDescending(x => x.Followers.Count()).ThenBy(x => x.Following.Count()))
                {
                    Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                    count++;
                }
            }
        }
    }
}


public class Vlogger
{
    public string Name { get; set; }
    public HashSet<string> Followers { get; set; }
    public HashSet<string> Following { get; set; }

    public Vlogger(string name)
    {
        this.Name = Name;
        this.Followers = new HashSet<string>();
        this.Following = new HashSet<string>();
    }

    public void AddFollowing(string name)
    {
        Following.Add(name);
    }

    public void AddFollower(string name)
    {
        Followers.Add(name);
    }
}

