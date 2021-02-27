using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.Collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
