using System;

namespace CarManufacturer
{
    static class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "Vw";
            car.Model = "MK3";
            car.Year = 1992;
            Console.WriteLine($"Make: {car.Make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");
        }
    }
}
