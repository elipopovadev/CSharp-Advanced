using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            int initialGreenLightSeconds = greenLightSeconds;
            int initialFreeWindowSeconds = freeWindowSeconds;
            var queueForAllCars = new Queue<string>();
            int countPassedCars = 0;
            string input;
            while ((input=Console.ReadLine())!="END")
            {          
                if (input != "green")
                {
                    string car = input;
                    queueForAllCars.Enqueue(car);
                    continue;
                }

                if (input == "green")
                {
                    greenLightSeconds = initialGreenLightSeconds;
                    freeWindowSeconds = initialFreeWindowSeconds;

                    while (greenLightSeconds > 0 && queueForAllCars.Count > 0) // there are green light and some cars
                    {
                        string currentCar = queueForAllCars.Peek();
                        int currentCarLength = currentCar.Length;
                        if (greenLightSeconds >= currentCarLength) // the whole car passed
                        {
                            greenLightSeconds = TheWholeCarPassedDurringGreenLight(greenLightSeconds, queueForAllCars, currentCarLength);
                            countPassedCars++;
                        }

                        else if (greenLightSeconds < currentCarLength)
                        {
                            var queueForCurrentCar = new Queue<char>(); // put the currentCarName in another queue

                            for (int i = 0; i < currentCarLength; i++)
                            {
                                queueForCurrentCar.Enqueue(currentCar[i]);
                            }

                            greenLightSeconds = SomeCarPartsPassedDuringGreenLight(greenLightSeconds, queueForCurrentCar); // car parts passed durring green light

                            if (freeWindowSeconds >= queueForCurrentCar.Count) // car parts passed durring free window
                            {
                                freeWindowSeconds = ТheRestPartAndTheWholeCarPassedDuringFreeWindow(queueForAllCars, queueForCurrentCar);
                                countPassedCars++;
                            }

                            else if (freeWindowSeconds < queueForCurrentCar.Count) // there is a crash
                            {
                                WhatHappendIfThereIsACrash(freeWindowSeconds, currentCar, queueForCurrentCar);
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countPassedCars} total cars passed the crossroads.");
        }



        private static int TheWholeCarPassedDurringGreenLight(int greenLightSeconds, Queue<string> queue, int currentCarLength)
        {
            queue.Dequeue(); // car passed durring green light
            greenLightSeconds -= currentCarLength;
            return greenLightSeconds;
        }

        private static int SomeCarPartsPassedDuringGreenLight(int greenLightSeconds, Queue<char> queueForCurrentCar)
        {
            for (int i = 0; i < greenLightSeconds; i++) // only some car parts passed durring green light
            {
                queueForCurrentCar.Dequeue();
            }

            greenLightSeconds = 0;
            return greenLightSeconds;
        }

        private static int ТheRestPartAndTheWholeCarPassedDuringFreeWindow(Queue<string> queueForAllCars, Queue<char> queueForCurrentCar)
        {
            int freeWindowSeconds;
            for (int i = 0; i < queueForCurrentCar.Count; i++)
            {
                queueForCurrentCar.Dequeue();
            }

            freeWindowSeconds = 0; // red light
            queueForAllCars.Dequeue(); // currentCar passed 
            return freeWindowSeconds;
        }

        private static void WhatHappendIfThereIsACrash(int freeWindowSeconds, string currentCar, Queue<char> queueForCurrentCar)
        {
            char crashSymbol = currentCar[0];
            for (int i = 0; i <= freeWindowSeconds; i++)
            {
                if (queueForCurrentCar.TryPeek(out char currenSymbol))
                {
                    crashSymbol = queueForCurrentCar.Dequeue();
                }
            }

            Console.WriteLine($"A crash happened!");
            Console.WriteLine($"{currentCar} was hit at {crashSymbol}.");
            return;
        }
    }
}
