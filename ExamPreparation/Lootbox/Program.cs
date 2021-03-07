using System;
using System.Linq;
using System.Collections.Generic;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondLines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> firstLoot = new Queue<int>(firstLines);
            Stack<int> secondLoot = new Stack<int>(secondLines);

            int countClaimedItems = 0;
            while (firstLoot.Count > 0 && secondLoot.Count > 0)
            {
                int firstValue = firstLoot.Peek();
                int secondValue = secondLoot.Peek();
                int sum = firstValue + secondValue;
                if (sum % 2 == 0)
                {
                    firstLoot.Dequeue();
                    secondLoot.Pop();
                    countClaimedItems += sum;
                }

                else
                {
                    firstLoot.Enqueue(secondValue);
                    secondLoot.Pop();
                }
            }

            if (firstLoot.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            else if (secondLoot.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if(countClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {countClaimedItems}");
            }

            else
            {
                Console.WriteLine($"Your loot was poor... Value: {countClaimedItems}");
            }
        }
    }
}
