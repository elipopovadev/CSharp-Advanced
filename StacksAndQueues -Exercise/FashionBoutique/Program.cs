using System;
using System.Collections.Generic;
using System.Linq;


namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valueOfTheClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(valueOfTheClothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int countRacks = 1;
            int sumClothesValue = 0;
            while (stack.Count > 0)
            {
                int currentClothesValue = stack.Peek();
                sumClothesValue += currentClothesValue;
                if (sumClothesValue <= rackCapacity)
                {
                    stack.Pop();
                }

                else if (sumClothesValue > rackCapacity)
                {
                    sumClothesValue = 0;
                    countRacks++;
                }
            }

            Console.WriteLine(countRacks);
        }
    }
}
