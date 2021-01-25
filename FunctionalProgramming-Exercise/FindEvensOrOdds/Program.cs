using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lowerBound = range[0];
            int upperBound = range[1];
            string condition = Console.ReadLine();
            Func<int, int, int[]> funcToListNumber = (lowerBound, upperBound) =>
            {
                var newListWithNumbers = new List<int>();              
                for (int i = lowerBound; i <= upperBound; i++)
                {
                    newListWithNumbers.Add(i);
                }

                return newListWithNumbers.ToArray();
            };

            if (condition == "odd")
            {
                Console.WriteLine(string.Join(" ",funcToListNumber(lowerBound,upperBound).Where(x=>x % 2 != 0)));
            }

            else if (condition == "even")
            {
                Console.WriteLine(string.Join(" ", funcToListNumber(lowerBound,upperBound).Where(x=>x % 2 == 0)));
            }
        }
    }
}
