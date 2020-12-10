using System;
using System.Linq;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split().ToArray();
            string[] reverseNumbers = numbers.Reverse().ToArray();
            var stack = new Stack<string>(reverseNumbers);
            while (stack.Count > 1)
            {
                int firstNumber =int.Parse(stack.Pop());
                string sign = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                if (sign == "+")
                {
                    string result = (firstNumber + secondNumber).ToString();
                    stack.Push(result);
                }

                else if (sign == "-")
                {
                    string result = (firstNumber - secondNumber).ToString();
                    stack.Push(result);
                }
            }

            Console.WriteLine(stack.Pop());



        }
    }
}
