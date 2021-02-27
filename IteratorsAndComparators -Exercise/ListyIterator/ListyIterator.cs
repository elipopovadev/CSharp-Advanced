using System;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private int currentIndex;
        public ListyIterator(List<T> collection)
        {
            this.Collection = collection;
            this.currentIndex = 0;
        }

        public List<T> Collection { get; }

        public bool Move()
        {
            if(this.currentIndex < this.Collection.Count - 1)
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex < this.Collection.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.Collection.Count > 0)
            {
                Console.WriteLine(this.Collection[currentIndex]);
            }

            else
            {
                throw new InvalidOperationException("Invalid operation!");
            }         
        }
    }
}
