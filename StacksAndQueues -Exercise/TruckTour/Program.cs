using System;
using System.Linq;
using System.Collections.Generic;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfPumps = int.Parse(Console.ReadLine());
            var queueForPetrol = new Queue<int>();
            var queueForDistance = new Queue<int>();
            var queueForIndex = new Queue<int>();
            for (int i = 0; i < numbersOfPumps; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int quantityPetrolInThePump = input[0];
                queueForPetrol.Enqueue(quantityPetrolInThePump);
                int distanceBetwenTheNext = input[1];
                queueForDistance.Enqueue(distanceBetwenTheNext);
                queueForIndex.Enqueue(i);
            }

            int amountPetrolInTheTruck = 0;
            int countPassedPump = 0;
            int index = 0;

            while (countPassedPump != numbersOfPumps + 1) // condition to complete the circle
            {
                int petrol = queueForPetrol.Peek();
                int distance = queueForDistance.Peek();
                index = queueForIndex.Peek();
                amountPetrolInTheTruck += petrol;
                if (amountPetrolInTheTruck >= distance)
                {
                    countPassedPump++;
                    MoveFirstElementsToTheLastPositions(queueForPetrol, queueForDistance, queueForIndex, index, petrol, distance);
                    amountPetrolInTheTruck -= distance;
                }

                else if (amountPetrolInTheTruck < distance)
                {
                    countPassedPump = 0;
                    amountPetrolInTheTruck = 0;
                    MoveFirstElementsToTheLastPositions(queueForPetrol, queueForDistance, queueForIndex, index, petrol, distance);
                }
            }

            Console.WriteLine(index);
        }


        private static void MoveFirstElementsToTheLastPositions(Queue<int> queueForPetrol, Queue<int> queueForDistance, Queue<int> queueForIndex, int index, int petrol, int distance)
        {
            queueForDistance.Dequeue();
            queueForPetrol.Dequeue();
            queueForIndex.Dequeue();
            queueForDistance.Enqueue(distance);
            queueForPetrol.Enqueue(petrol);
            queueForIndex.Enqueue(index);
        }
    }
}

