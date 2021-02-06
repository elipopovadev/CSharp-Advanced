using System;

namespace SpeedRacing
{
    public static class StartUp
    {
        static void Main(string[] args)
        {
            var carRegister = new CarRegister();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputArray = Console.ReadLine().Split();
                string model = inputArray[0];
                double fuelAmount = double.Parse(inputArray[1]);
                double fuelConsumptionPerKilometer = double.Parse(inputArray[2]);
                var newCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                carRegister.AddCar(newCar);
            }

            string input;
            while ((input = Console.ReadLine())!= "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                inputArray[0] = "Drive";
                string model = inputArray[1];
                double amountOfKm = double.Parse(inputArray[2]);
                var currentCar = carRegister.FindCarInCarsRegister(model);
                currentCar.Drive(amountOfKm);
            }

            carRegister.PrintCars();
        }
    }
}
