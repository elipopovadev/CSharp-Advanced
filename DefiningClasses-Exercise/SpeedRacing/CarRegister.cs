using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class CarRegister
    {
        public CarRegister()
        {
            this.CarsRegister = new List<Car>();
        }

        public List<Car> CarsRegister { get; set; }

        public void AddCar(Car newCar)
        {
            if (!this.CarsRegister.Any(c => c.Model == newCar.Model))
            {
                this.CarsRegister.Add(newCar);
            }
        }

        public Car FindCarInCarsRegister(string model)
        {
            var car = this.CarsRegister.Where(c => c.Model == model).FirstOrDefault();
            return car;
        }

        public void PrintCars()
        {
            foreach (var car in this.CarsRegister)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
