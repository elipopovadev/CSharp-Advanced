using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleCatalogue
{
   public class Program
    {
        static void Main(string[] args)
        {
            var trucksCatalogue = new List<Truck>();
            var carsCatalogue = new List<Car>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = inputArray[0];
                string model = inputArray[1];
                string color = inputArray[2];
                int horsepower = int.Parse(inputArray[3]);
                if (type == "car" && !carsCatalogue.Any(c => c.Model == model))
                {
                    var newCar = new Car(model, color, horsepower);
                    carsCatalogue.Add(newCar);
                }

                else if (type == "truck" && !trucksCatalogue.Any(t => t.Model == model))
                {
                    var newTruck = new Truck(model, color, horsepower);
                    trucksCatalogue.Add(newTruck);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                string model = command;
                if (carsCatalogue.Any(c => c.Model == model))
                {
                    Console.WriteLine("Type: Car");
                    var findCar = carsCatalogue.First(c => c.Model == model);
                    Console.WriteLine(findCar.ToString());
                }

                else if (trucksCatalogue.Any(t => t.Model == model))
                {
                    Console.WriteLine("Type: Truck");
                    var findTruck = trucksCatalogue.First(t => t.Model == model);
                    Console.WriteLine(findTruck.ToString());
                }
            }

            PrintAverageHoursepowers(trucksCatalogue, carsCatalogue);
        }


        private static void PrintAverageHoursepowers(List<Truck> trucksCatalogue, List<Car> carsCatalogue)
        {
            var averageCarsHorsePower = carsCatalogue.Select(c => c.Horsepower).Sum() > 0 ? carsCatalogue.Select(c => c.Horsepower).Average() : 0;
            var averageTrucksHorsePower = trucksCatalogue.Select(t => t.Horsepower).Sum() > 0 ? trucksCatalogue.Select(c => c.Horsepower).Average() : 0;
            Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:F2}.");
        }
    }


    public class Car
    {
        public Car(string model, string color, int horsepower)
        {
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.Horsepower}");
            return sb.ToString().Trim();
        }
    }


    public class Truck
    {
        public Truck(string model, string color, int horsepower)
        {
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.Horsepower}");
            return sb.ToString().Trim();
        }
    }
}
