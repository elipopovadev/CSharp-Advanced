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

        public void AddPerson(Person name)
        {
            if (!ListWithPersons.Contains(name))
            {
                this.ListWithPersons.Add(name);
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
