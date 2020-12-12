using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            int numbersOfQueries = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfQueries; i++)
            {
                string querie = Console.ReadLine();
                string[] querieArray = querie.Split();
                if (querieArray[0] == "1")
                {
                    int elementToPush = int.Parse(querieArray[1]);
                    stack.Push(elementToPush);
                }

                else if (querieArray[0] == "2" && stack.Count > 0)
                {
                    stack.Pop();
                }

                else if (querieArray[0] == "3" && stack.Count > 0)
                {
                    int[] arrayFromTheStack = stack.ToArray();
                    int maxElement = arrayFromTheStack.Max();
                    Console.WriteLine(maxElement);
                }

                else if (querieArray[0] == "4" && stack.Count > 0)
                {
                    int[] arrayFromTheStack = stack.ToArray();
                    int minElement = arrayFromTheStack.Min();
                    Console.WriteLine(minElement);
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
