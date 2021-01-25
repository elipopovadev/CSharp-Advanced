using System;
using System.IO;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> action = x => Console.WriteLine(string.Join (Environment.NewLine, "Sir" + " " + names.ToString()));
            action(names);
           

        }
    }
}
