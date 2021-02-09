using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.Capacity = capacity;
        }

        public int Capacity { get => capacity; set => capacity = value; }
        public List<Car> Cars { get => cars; set => cars = value; }
        public int Count => this.Cars.Count();

        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }

            else if (this.Cars.Count == this.Capacity)
            {
                return $"Parking is full!";
            }

            else
            {
                this.Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }

            else
            {
                Car findedCar = this.Cars.First(c => c.RegistrationNumber == registrationNumber);
                this.Cars.Remove(findedCar);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {
                if (this.Cars.Any(c => c.RegistrationNumber == number))
                {
                    Car findedCar = this.Cars.First(c => c.RegistrationNumber == number);
                    this.Cars.Remove(findedCar);
                }
            }
        }
    }
}
