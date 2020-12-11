using System;
using System.Collections.Generic;
using System.Linq;


namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            int[] input = new int[3];
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int enqeueNumbers = input[0];
            int deqeueNumbers = input[1];
            int numberToFind = input[2];
            int[] numbersArray = new int[enqeueNumbers];
            numbersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int number in numbersArray)
            {
                queue.Enqueue(number);
            }

            for (int i = 0; i < deqeueNumbers && deqeueNumbers <= enqeueNumbers; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }

            else if (queue.Contains(numberToFind) == false && queue.Count > 0)
            {
                int[] arrayfromTheQueue = queue.ToArray();
                int minNumber = arrayfromTheQueue.Min();
                Console.WriteLine(minNumber);
            }

            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}

