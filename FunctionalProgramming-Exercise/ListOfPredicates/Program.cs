using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int, int[]> funcCreateArray = x =>
            {
                var list = new List<int>();
                for (int i = 1; i <= x; i++)
                {
                    list.Add(i);
                }

                return list.ToArray();
            };

            var newArray = funcCreateArray(range);
            foreach (var num in dividers)
            {
               newArray= newArray.Where(x => x % num == 0).ToArray();
            }
            
            Console.WriteLine(string.Join(" ", newArray));
        }
    }
}
