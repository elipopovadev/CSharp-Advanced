using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int number = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(names);
            int count = 1;
            while (queue.Count > 1)
            {
                if (count == number)
                {
                    string removed = queue.Dequeue();
                    Console.WriteLine($"Removed {removed}");
                    count = 1;
                }

                else
                {
                    string name = queue.Dequeue();
                    queue.Enqueue(name);
                    count++;
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}