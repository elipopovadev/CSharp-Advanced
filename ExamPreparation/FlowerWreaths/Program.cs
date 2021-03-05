using System;
using System.Linq;
using System.Collections.Generic;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var lilies = new Stack<int>(firstLine);
            var roses = new Queue<int>(secondLine);

            int countFlowerWreaths = 0;
            int countStoredFlowers = 0;
            while(lilies.Count > 0 && roses.Count > 0)
            {
                int currentLily = lilies.Peek();
                int currentRoses = roses.Peek();
                int sum = currentLily + currentRoses;
                if(sum == 15)
                {
                    countFlowerWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                if(sum < 15)
                {
                    countStoredFlowers += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }

                else if(sum > 15)
                {
                    lilies.Pop();
                    lilies.Push(currentLily - 2);
                }
            }

            int createdMoreWreaths = countStoredFlowers / 15;
            int totalCountOfFlowerWreaths = countFlowerWreaths + createdMoreWreaths;
            if(totalCountOfFlowerWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {totalCountOfFlowerWreaths} wreaths!");
            }

            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - totalCountOfFlowerWreaths} wreaths more!");
            }
        }
    }
}
