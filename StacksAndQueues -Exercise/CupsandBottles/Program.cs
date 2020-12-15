using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queueForCupsCapacity = new Queue<int>(cupsCapacity);
            int[] bottleWithWatter = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stackForBottleWithWater = new Stack<int>(bottleWithWatter);
            int wastedWater = 0;
            while (queueForCupsCapacity.Count > 0 && stackForBottleWithWater.Count > 0)
            {
                int currentBottel = stackForBottleWithWater.Peek();
                int currentCupValue = queueForCupsCapacity.Peek();
                if (currentCupValue > currentBottel) // the currentCup is bigger than the currentBottel
                {
                    int reducedCupValue = currentCupValue - currentBottel; // filling is done and there is left capacity in the cup
                    stackForBottleWithWater.Pop();
                    while (reducedCupValue > 0 && stackForBottleWithWater.Count > 0) // until reducedCupValue <= 0 or there aren't any bottels
                    {
                        int nextBottel = stackForBottleWithWater.Peek(); // let's filling the cup with the nextBottel
                        if (nextBottel > reducedCupValue)
                        {
                            wastedWater = wastedWater + (nextBottel - reducedCupValue); //there are wastedWater
                            reducedCupValue -= nextBottel;
                        }

                        else
                        {
                            reducedCupValue -= nextBottel; // reducedCupValue <= 0 and there aren't wastedWater
                        }

                        stackForBottleWithWater.Pop(); // every time remove the currentBottel
                    }

                    queueForCupsCapacity.Dequeue(); // in the end remove the currentCup, because reducedCupValue <= 0
                }

                else if (currentBottel >= currentCupValue) // the currentBottel is bigger than the currentCup
                {
                    wastedWater = wastedWater + (currentBottel - currentCupValue);
                    stackForBottleWithWater.Pop();
                    queueForCupsCapacity.Dequeue();
                }
            }

            if (stackForBottleWithWater.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackForBottleWithWater)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }

            else if (queueForCupsCapacity.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queueForCupsCapacity)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}