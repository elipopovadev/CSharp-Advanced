using System;
using System.Collections.Generic;
using System.Linq;


namespace PeriodicTable
{
    static class Program
    {
        static void Main(string[] args)
        {
            int numberInputLines = int.Parse(Console.ReadLine());
            var setWithElements = new SortedSet<string>();
            for (int i = 0; i < numberInputLines; i++)
            {
                string[] inputLine = Console.ReadLine().Split().ToArray();
                foreach (var chemicalElement in inputLine)
                {
                    setWithElements.Add(chemicalElement);
                }
            }

            Console.WriteLine(string.Join(" ", setWithElements));
        }
    }
}
