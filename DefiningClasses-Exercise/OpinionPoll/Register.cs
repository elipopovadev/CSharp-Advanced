using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    class Register
    {
        public Register()
        {
            this.ListWithPersons = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            if (!ListWithPersons.Any(p=> p.Name == person.Name))
            {
                this.ListWithPersons.Add(person);
            }
        }

        public List<Person> GetOldersThanThirty()
        {
            var filterList = this.ListWithPersons.Where(x => x.Age > 30).ToList();
            return filterList;
        }

        public List<Person> ListWithPersons { get; set; }
    }
}
