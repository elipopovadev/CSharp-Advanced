using System;

namespace CreateCustomStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine(stack.Peek()); // 5
            stack.Pop();
            foreach (var item in stack)
            {
                Console.WriteLine(item); // 1 2 3 4
            }

            Console.WriteLine(stack.Count); // 4
        }
    }
}
