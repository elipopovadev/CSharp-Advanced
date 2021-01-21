using System;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray=Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                 .Where(x => x % 2 == 0).OrderBy(x => x).ToArray();
            foreach (var number in intArray)
            {
                Console.Write(number + ", ");
            }           
        }
    }
}
