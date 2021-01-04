using System;
using System.Collections.Generic;


namespace ParkingLot
{
    static class Program
    {
        static void Main(string[] args)
        {
            var hashSetNumber = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] inputArray = input.Split(", ");
                string direction = inputArray[0];
                string carNumber = inputArray[1];
                if (direction == "IN")
                {
                    hashSetNumber.Add(carNumber);
                }

                else if (direction == "OUT")
                {
                    hashSetNumber.Remove(carNumber);
                }
            }

            if (hashSetNumber.Count != 0)
            {
                foreach (var carNumber in hashSetNumber)
                {
                    Console.WriteLine(carNumber);
                }
            }

            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}
