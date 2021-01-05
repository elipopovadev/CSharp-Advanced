using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    static class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictNumberTimes = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!dictNumberTimes.ContainsKey(number))
                {                 
                    dictNumberTimes.Add(number,1);
                }

                else
                {
                    dictNumberTimes[number]++;
                }
            }

            var result = dictNumberTimes.Where(x => x.Value % 2 == 0).Select(x=> x.Key);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
