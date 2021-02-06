using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
            : this(model, fuelAmount, fuelConsumptionPerKilometer)
        {
            this.TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }
        public List<Car> CarsRegister { get; set; }

        public void Drive(double travelledDistance)
        {
            if (travelledDistance * this.FuelConsumptionPerKilometer <= this.FuelAmount)
            {
                this.FuelAmount -= travelledDistance * this.FuelConsumptionPerKilometer;
                this.TravelledDistance += travelledDistance;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
