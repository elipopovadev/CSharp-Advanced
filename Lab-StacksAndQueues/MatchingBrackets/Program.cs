using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            var stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }

                else if (expression[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    int substringLength = endIndex - startIndex + 1;
                    string substring = expression.Substring(startIndex, substringLength);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
