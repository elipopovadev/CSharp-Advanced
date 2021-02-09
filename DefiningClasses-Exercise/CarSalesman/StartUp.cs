using System;
using System.Collections.Generic;
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
                    string power = inputArray[1];
                    Engine newEngine = new Engine(model, power);
                    listOfEngines.Add(newEngine);
                }

                else if (inputArray.Length == 3)
                {
                    string model = inputArray[0];
                    string power = inputArray[1];
                    string thirdParam = inputArray[2]; //displacement or efficiency
                    if (char.IsDigit(thirdParam[0]))
                    {
                        string displacement = inputArray[2];
                        Engine newEngine = new Engine(model, power, displacement, "n/a");
                        listOfEngines.Add(newEngine);
                    }

                    else
                    {
                        string efficiency = inputArray[2];
                        Engine newEngine = new Engine(model, power, "n/a", efficiency);
                        listOfEngines.Add(newEngine);
                    }
                }

                else if (inputArray.Length == 4)
                {
                    string model = inputArray[0];
                    string power = inputArray[1];
                    string displacement = inputArray[2];
                    string efficiency = inputArray[3];
                    Engine newEngine = new Engine(model, power, displacement, efficiency);
                    listOfEngines.Add(newEngine);
                }
            }

            int carsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNumber; i++)
            {
                string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inputArray.Length == 2)
                {
                    string model = inputArray[0];
                    string engineModel = inputArray[1];
                    if (listOfEngines.Exists(e => e.Model == engineModel))
                    {
                        Engine findEngine = listOfEngines.Where(e => e.Model == engineModel).First();
                        Car newCar = new Car(model, findEngine);
                        listOfCars.Add(newCar);
                    }
                }

                else if (inputArray.Length == 3)
                {
                    string model = inputArray[0];
                    string engineModel = inputArray[1];
                    string thirdParam = inputArray[2]; // weight or color

                    if (listOfEngines.Any(e => e.Model == engineModel))
                    {
                        Engine findedEngine = listOfEngines.Where(e => e.Model == engineModel).First();
                        if (char.IsDigit(thirdParam[0]))
                        {
                            string weight = inputArray[2];
                            var newCar = new Car(model, findedEngine, weight, "n/a");
                            listOfCars.Add(newCar);
                        }

                        else
                        {
                            string color = inputArray[2];
                            var newCar = new Car(model, findedEngine, "n/a", color);
                            listOfCars.Add(newCar);
                        }
                    }
                }

                else if (inputArray.Length == 4)
                {
                    string model = inputArray[0];
                    string engineModel = inputArray[1];
                    string weight = inputArray[2];
                    string color = inputArray[3];
                    if (listOfEngines.Any(e => e.Model == engineModel))
                    {
                        Engine findedEngine = listOfEngines.Where(e => e.Model == engineModel).First();
                        var newCar = new Car(model, findedEngine, weight, color);
                        listOfCars.Add(newCar);
                    }
                }
            }

            foreach (var car in listOfCars)
            {
                Console.WriteLine(car.Model);
                Console.WriteLine(car.Engine.Model);
                Console.WriteLine($"Power: {car.Engine.Power}");
                Console.WriteLine($"Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"Weight: {car.Weight}");
                Console.WriteLine($"Color: {car.Color}");
            }
        }
    }
}