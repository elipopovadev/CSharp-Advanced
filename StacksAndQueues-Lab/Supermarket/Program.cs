using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            var queue = new Queue<string>();
            while (name != "End")
            {
                if (name == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        string namePaid = queue.Dequeue();
                        Console.WriteLine(namePaid);
                    }

                    name = Console.ReadLine();
                }

                else if (name != "Paid")
                {
                    queue.Enqueue(name);
                    name = Console.ReadLine();
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
