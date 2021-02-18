using System;

namespace CreateCustomQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            queue.Enqueue("4");
            queue.Enqueue("5");
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine(queue.Peek()); // 3

            foreach (var item in queue)
            {
                Console.WriteLine(item); // 3 4 5
            }           
        }
    }
}
