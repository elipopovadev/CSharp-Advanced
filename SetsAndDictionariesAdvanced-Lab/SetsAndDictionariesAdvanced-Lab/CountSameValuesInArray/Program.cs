using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    static class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var dictElementOccurrence = new Dictionary<double, int>();
            foreach (var number in array)
            {
                if (!dictElementOccurrence.ContainsKey(number))
                {
                    dictElementOccurrence[number] = 0;
                }

                dictElementOccurrence[number]++;
            }

            foreach ( var (number, occurence) in dictElementOccurrence)
            {
                Console.WriteLine($"{number} - {occurence} times");
            }
        }
    }
}
