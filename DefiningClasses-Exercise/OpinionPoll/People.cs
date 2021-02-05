using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    class People
    {
        public People()
        {
            this.ListWithAllPeople = new List<Person>();
        }

        public void AddPerson(Person name)
        {
           this.ListWithAllPeople.Add(name);
        }
       
        public List<Person> GetOldersThanThirty()
        {
            var filterList = this.ListWithAllPeople.Where(x => x.Age > 30).ToList();
            return filterList;
        }   

        public List<Person> ListWithAllPeople {get; set;}
    }
}
