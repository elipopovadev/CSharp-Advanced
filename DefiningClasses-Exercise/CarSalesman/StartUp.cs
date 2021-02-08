using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarSalesman
{
    public static class StartUp
    {
        static void Main(string[] args)
        {
            var listOfEngines = new List<Engine>();
            var listOfCars = new List<Car>();
            int enginesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesNumber; i++)
            {
                string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inputArray.Length == 2)
                {
                    string model = inputArray[0];
                    int power = int.Parse(inputArray[1]);
                    var newEngine = new Engine(model, power);
                    listOfEngines.Add(newEngine);
                }

                else if(inputArray.Length == 4)
                {
                    string model = inputArray[0];
                    int power = int.Parse(inputArray[1]);
                    string displacement = inputArray[2];
                    int efficiency = int.Parse(inputArray[3]);
                    var newEngine = new Engine(model, power, displacement, efficiency);
                    listOfEngines.Add(newEngine);
                }
            }

            int carsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNumber; i++)
            {
                string[] inputArray = Console.ReadLine().Split();
                if (inputArray.Length == 2)
                {
                    string model = inputArray[0];
                    string engineModel = inputArray[1];
                    if (listOfEngines.Any(e => e.Model == model))
                    {
                        var findEngine = listOfEngines.First(e => e.Model == model);
                        var newCar = new Car(model, findEngine);
                    }
                }
                else if(inputArray.Length == 4)
                {
                    string model = inputArray[0];
                    string engineModel = inputArray[1];
                    int weight = int.Parse(inputArray[2]);
                    string color = inputArray[3];
                    if (listOfEngines.Any(e => e.Model == model))
                    {
                        var findEngine = listOfEngines.First(e => e.Model == model);
                        var newCar = new Car(model, findEngine, weight ,color);
                    }
                }
                
            }

        }
    }
}
