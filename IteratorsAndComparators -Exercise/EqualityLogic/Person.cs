using System;

namespace EqualityLogic
{
    class Person : IComparable<Person>, IEquatable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set;}
        public int Age { get; set;}

        public int CompareTo( Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Age.CompareTo(other.Age);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }

        public bool Equals( Person other)
        {
            return other != null && this.Name == other.Name
                && this.Age == other.Age;
        }
    }
}
