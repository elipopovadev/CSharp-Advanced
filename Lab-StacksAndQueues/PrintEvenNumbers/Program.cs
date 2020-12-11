using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    queue.Enqueue(numbers[i]);
                }
            }

<<<<<<< HEAD
            Console.WriteLine(string.Join(", ", queue));                    
=======
            Console.WriteLine(string.Join(", ", queue));                     
>>>>>>> 3ac53ba182a4cd5f58f8de0e6c929719ab98aa34
        }
    }
}
