using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public static class StartUp
    {
        static void Main(string[] args)
        {
            var carRegister = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputArray = Console.ReadLine().Split();
                string model = inputArray[0];
                int engineSpeed = int.Parse(inputArray[1]);
                int enginePower = int.Parse(inputArray[2]);
                int cargoWeight = int.Parse(inputArray[3]);
                string cargoType = inputArray[4];
                double tire1Pressure = double.Parse(inputArray[5]);
                int tire1Age = int.Parse(inputArray[6]);
                double tire2Pressure = double.Parse(inputArray[7]);
                int tire2Age = int.Parse(inputArray[8]);
                double tire3Pressure = double.Parse(inputArray[9]);
                int tire3Age = int.Parse(inputArray[10]);
                double tire4Pressure = double.Parse(inputArray[11]);
                int tire4Age = int.Parse(inputArray[12]);

                var newEngine = new Engine(engineSpeed, enginePower);
                var newCargo = new Cargo(cargoWeight, cargoType);
                var firstTire = new Tire(tire1Pressure, tire1Age);
                var secondTire = new Tire(tire2Pressure, tire2Age);
                var thirdTire = new Tire(tire3Pressure, tire3Age);
                var fourthTire = new Tire(tire4Pressure, tire4Age);
                var tires = new List<Tire>();
                tires.Add(firstTire);
                tires.Add(secondTire);
                tires.Add(thirdTire);
                tires.Add(fourthTire);

                var newCar = new Car(model, newEngine, newCargo, tires.ToArray());
                carRegister.Add(newCar);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                var filteredCars = carRegister.Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.TirePressure < 1));
                PrintFilteredCars(filteredCars);
            }

            else if (command == "flamable")
            {
                var filteredCars = carRegister.Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250);
                PrintFilteredCars(filteredCars);
            }
        }


        private static void PrintFilteredCars(IEnumerable<Car> filteredCars)
        {
            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
