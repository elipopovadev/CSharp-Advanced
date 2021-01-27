using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbers, (x, y) =>
            {
                int compare = 0;
                if (x % 2 == 0 && y % 2 != 0)
                {
                    compare = -1;
                }

                else if (x % 2 != 0 && y % 2 == 0)
                {
                    compare = 1;
                }

                else if (x < y)
                {
                    compare = -1;
                }

                else if (x > y)
                {
                    compare = 1;
                }

                return compare;
            });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
