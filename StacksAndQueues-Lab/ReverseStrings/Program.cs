using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<char>(input);
            while (stack.Count > 0)
            {
                char symbol = stack.Pop();
                Console.Write(symbol);
            }
        }
    }
}
