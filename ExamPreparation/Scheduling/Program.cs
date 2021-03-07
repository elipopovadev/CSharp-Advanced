using System;
using System.Linq;
using System.Collections.Generic;

namespace Scheduling
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] firstLines = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondLines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int valueToKill = int.Parse(Console.ReadLine());
            var tasks = new Stack<int>(firstLines);
            var threads = new Queue<int>(secondLines);

            while(tasks.Count > 0 && threads.Count > 0)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if(currentTask == valueToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                    Console.WriteLine(string.Join(" ",threads));
                    return;
                }

                else if(currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }

                else if(currentThread < currentTask)
                {
                    threads.Dequeue();
                }
            }         
        }
    }
}
