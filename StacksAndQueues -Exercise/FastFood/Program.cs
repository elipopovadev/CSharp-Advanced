using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityPerDay = int.Parse(Console.ReadLine());
            int[] quantityOfTheOrders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxOrder = quantityOfTheOrders.Max();
            Console.WriteLine(maxOrder);
            var queue = new Queue<int>(quantityOfTheOrders);
            while (queue.Count > 0)
            {
                int currentOrderQuantity = queue.Peek();
                if (quantityPerDay >= currentOrderQuantity)
                {
                    queue.Dequeue();
                    quantityPerDay -= currentOrderQuantity;
                }

                else if (quantityPerDay < currentOrderQuantity)
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
