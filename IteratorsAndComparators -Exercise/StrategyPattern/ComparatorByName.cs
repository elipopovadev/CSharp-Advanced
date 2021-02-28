using System.Collections.Generic;

namespace StrategyPattern
{
    class ComparatorByName : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            if (firstPerson.Name.Length.CompareTo(secondPerson.Name.Length) != 0)
            {
                return firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);
            }

            return firstPerson.Name[0].ToString().ToLower().CompareTo(secondPerson.Name[0].ToString().ToLower());
        }
    }
}
