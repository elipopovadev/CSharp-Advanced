using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x - 1;
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                       numbers= numbers.Select(add).ToArray();
                        break;
                    case "multiply":
                      numbers=  numbers.Select(multiply).ToArray();
                        break;
                    case "subtract":
                       numbers= numbers.Select(subtract).ToArray();
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
