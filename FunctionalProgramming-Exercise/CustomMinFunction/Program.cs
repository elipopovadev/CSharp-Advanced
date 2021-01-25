using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> funcMinNumber = nums =>
             {
                 int minValue = int.MaxValue;
                 foreach (var num in numbers)
                 {
                     if (num < minValue)
                     {
                         minValue = num;
                     }
                 }

                 return minValue;
             };

            Console.WriteLine(funcMinNumber(numbers));
        }
    }
}
