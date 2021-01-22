using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).Select(x => (0.2 * x) + x).ToArray();
            foreach (var number in input)
            {
                Console.WriteLine($"{number:f2}");
            }         
        }
    }
}
