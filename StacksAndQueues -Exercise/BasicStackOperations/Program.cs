using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            int[] input = new int[3];
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int pushNumbersElements = input[0];           
            int popNumbersElements = input[1];
            int numberToFind = input[2];
            int[] arrayFromNumbers = new int[pushNumbersElements];
            arrayFromNumbers =Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < arrayFromNumbers.Length; i++)
            {             
                stack.Push(arrayFromNumbers[i]);
            }

            for (int i = 0; i < popNumbersElements && popNumbersElements<=pushNumbersElements; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numberToFind))
            {
                Console.WriteLine(true);
            }

            else if(stack.Contains(numberToFind)==false && stack.Count>0)
            {
                int [] arrayFromTheStack = stack.ToArray();
                int minNumber = arrayFromTheStack.Min();
                Console.WriteLine(minNumber);
            }

            else if(stack.Count==0)
            {
                Console.WriteLine(0);
            }
        }
    }
}
