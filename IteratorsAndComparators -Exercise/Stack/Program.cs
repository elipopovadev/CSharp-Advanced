using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new stack();
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command.Contains("Push"))
                {
                    string[] elements = command.Split(new char[] { ' ', ','},StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                    int[] elementsInInt = elements.Select(int.Parse).ToArray();
                    stack.Push(elementsInInt);
                }

                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch 
                    {
                        Console.WriteLine("No elements");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }    
        }
    }
}
