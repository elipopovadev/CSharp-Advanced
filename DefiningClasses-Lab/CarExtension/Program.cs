using System;

namespace CarExtension
{
    public static class CarManufacturer
    {
        public static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;
            car.Drive(20);
            Console.WriteLine(car.WhoAmI());                      
        }
    }
}
