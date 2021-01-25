using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().Select(x=> "Sir "+ x).ToArray();
            Action<string[]> actionPrint = x => Console.WriteLine(string.Join (Environment.NewLine, x));
            actionPrint(names);         
        }
    }
}
