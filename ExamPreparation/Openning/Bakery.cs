using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public List<Employee> date;
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.date = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Employee employee)
        {
            if (this.date.Count < this.Capacity)
            {
                this.date.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (this.date.Any(e => e.Name == name))
            {
                Employee foundedName = this.date.Where(e => e.Name == name).First();
                this.date.Remove(foundedName);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = this.date.OrderByDescending(e => e.Age).First();
            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            if (this.date.Any(e => e.Name == name))
            {
                Employee foundedName = this.date.Where(e => e.Name == name).First();
                return foundedName;
            }

            return null;
        }

        public int Count => this.date.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}");
            foreach (var empployee in this.date)
            {
                sb.AppendLine(empployee.ToString());
            }

            return sb.ToString().TrimEnd();               
        }
    }
}
