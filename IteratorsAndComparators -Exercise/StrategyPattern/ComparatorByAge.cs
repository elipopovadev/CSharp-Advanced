using System.Collections.Generic;

namespace StrategyPattern
{
    class ComparatorByAge : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}
