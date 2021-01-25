using System;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Action<string[]> action= x=> Console.WriteLine(string.Join(Environment.NewLine, input));
            action(input);         
        }
    }
}
