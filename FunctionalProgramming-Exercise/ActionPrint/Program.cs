using System;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().ToArray();
            Action<string[]> actionPrint= x => Console.WriteLine(string.Join(Environment.NewLine, x));
            actionPrint(names);         
        }
    }
}
