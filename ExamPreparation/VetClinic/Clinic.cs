using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
   public class Clinic
    {
        private List<Pet> data;
        public Clinic( int capacity )
        {          
            this.data = new List<Pet>();
            this.Capacity = capacity;
        }

        public int Capacity { get; }

        public void Add(Pet pet)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if(this.data.Any(p=> p.Name == name))
            {
                Pet foundedPet = this.data.Where(p => p.Name == name).First();
                this.data.Remove(foundedPet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            if(this.data.Any(p=>p.Name == name && p.Owner == owner))
            {
                Pet foundedPet = this.data.Where(p => p.Name == name && p.Owner == owner).First();
                return foundedPet;
            }

            return null;
        }

        public Pet GetOldestPet()
        {
            Pet oldestPet = this.data.OrderByDescending(p => p.Age).First();
            return oldestPet;
        }

        public int Count => this.data.Count();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
