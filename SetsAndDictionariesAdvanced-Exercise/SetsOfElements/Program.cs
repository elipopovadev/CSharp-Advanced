using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstSetLength = input[0];
            int secondSetLength = input[1];
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            for (int i = 0; i < firstSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            var thirdSet= firstSet.Intersect(secondSet);
            Console.WriteLine(string.Join(" ",thirdSet));
        }
    }
}
