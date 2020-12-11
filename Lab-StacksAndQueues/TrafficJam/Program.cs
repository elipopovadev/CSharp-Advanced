using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCarsPassed = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int countCarsPassed = 0;
            string car = Console.ReadLine();
            while (car != "end")
            {
                if (car == "green")
                {
                    for (int i = 0; i < numberCarsPassed; i++)
                    {
                        if (queue.TryDequeue(out string carPassed))
                        {
                            Console.WriteLine($"{carPassed} passed!");
                            countCarsPassed++;
                        }

                        else
                        {
                            break;
                        }
                    }
                }

                else if (car != "green")
                {
                    queue.Enqueue(car);
                }

                car = Console.ReadLine();
            }

            Console.WriteLine($"{countCarsPassed} cars passed the crossroads.");
        }
    }
}
