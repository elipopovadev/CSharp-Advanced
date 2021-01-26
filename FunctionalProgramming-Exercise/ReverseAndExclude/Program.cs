using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {         
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());          
            var newArray= numbers.Reverse().Where(x => x % n != 0).ToArray();
            Console.WriteLine(string.Join(" ", newArray));
        }
    }
}
