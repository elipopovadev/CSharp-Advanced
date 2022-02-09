using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                Car foundedCar = this.data.Where(c => c.Manufacturer == manufacturer && c.Model == model).First();
                this.data.Remove(foundedCar);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (this.data.Count > 0)
            {
                return this.data.OrderByDescending(c => c.Year).First();
            }

            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                Car foundedCar = this.data.Where(c => c.Manufacturer == manufacturer && c.Model == model).First();
                return foundedCar;
            }

            return null;
        }

        public int Count => this.data.Count;

        public string GetStatistics()

        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.data)

            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}



