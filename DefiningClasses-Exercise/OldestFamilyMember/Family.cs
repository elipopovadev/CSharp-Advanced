using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OldestFamilyMember
{
    public class Family
    {

        public Family()
        {
            this.FamilyList = new List<Person>();
        }

        public List<Person> FamilyList { get; set; }

        public void AddMember(Person member)
        {
            this.FamilyList.Add(member);
        }

         public Person GetOldestMember()
        {
            var oldestPerson = this.FamilyList.OrderByDescending (person=> person.Age).FirstOrDefault();
            return oldestPerson;          
        }

    }
}
