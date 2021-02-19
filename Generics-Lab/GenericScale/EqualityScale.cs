using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    class EqualityScale<T>
    {
        public EqualityScale(T first, T second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; }
        public T Second { get; }

        public bool AreEqual()
        {
            return this.First.Equals(this.Second);
        }
    }
}
