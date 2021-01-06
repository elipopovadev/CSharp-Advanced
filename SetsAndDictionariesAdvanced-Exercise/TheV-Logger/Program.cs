using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            var setOfVloggers = new HashSet<Vlogger>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Statistics")
                {
                    break;
                }


                if (input[1] == "joined")
                {
                    string name = input[0];
                    var newVlogger = new Vlogger(name);
                    setOfVloggers.Add(newVlogger);
                    newVlogger.Name = name;
                    newVlogger.Followers = new SortedSet<string>();
                    newVlogger.Following = new HashSet<string>();
                   
                }

                else if (input[1] == "followed")
                {
                    var firstVlogger = input[0];
                    var secondVlogger = input[2];
                    if (firstVlogger == secondVlogger) continue;
                    if (setOfVloggers.Any(x => x.Name == firstVlogger) && setOfVloggers.Any(x => x.Name == secondVlogger))
                    {
                        Vlogger findFirsVlogger = setOfVloggers.First(v => v.Name == firstVlogger);
                        findFirsVlogger.AddFollowing(secondVlogger);
                        Vlogger findSecondVlogger = setOfVloggers.First(v => v.Name == secondVlogger);
                        findSecondVlogger.AddFollower(firstVlogger);
                    }                     
                }
            }


        }




    }
}

public class Vlogger
{
    public string Name { get; set; }
    public SortedSet<string> Followers { get; set; }
    public HashSet<string> Following { get; set; }

    public Vlogger(string name)
    {
        this.Name = Name;
        this.Followers = new SortedSet<string>();
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

