using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class stack : IEnumerable<int>
    {
        public stack()
        {
            this.List = new List<int>();
        }
        public List<int> List { get; }

        public void Push(int[] list)
        {
            this.List.AddRange(list);
        }

        public int Pop()
        {       
            if (this.List.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            else
            {
                int lastIndex = this.List.Count - 1;
                int lastElement = this.List[lastIndex];
                this.List.RemoveAt(lastIndex);
                return lastElement;
            }         
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = this.List.Count- 1; i >= 0; i--)
            {
                yield return this.List[i];
            }

            for (int i = this.List.Count - 1; i >= 0; i--)
            {
                yield return this.List[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
