using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            var queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {

                string command = Console.ReadLine();
                if (command == "Play")
                {
                    queue.Dequeue();
                }

                else if (command.StartsWith("Add"))
                {
                    int songlength = command.Length - 4;
                    string song = command.Substring(4, songlength);
                    if (queue.Contains(song) == false)
                    {
                        queue.Enqueue(song);
                    }

                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }

                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}
