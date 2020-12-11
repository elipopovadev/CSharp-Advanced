using System;
using System.Linq;
using System.Collections.Generic;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(input);
            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandArray = command.Split();
                if (commandArray[0] == "add")
                {
                    int firstNumber = int.Parse(commandArray[1]);
                    int secondNumber = int.Parse(commandArray[2]);
                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }

                else if (commandArray[0] == "remove")
                {
                    int number = int.Parse(commandArray[1]);
                    if (number <= stack.Count)
                    {
                        for (int i = 0; i < number; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
