using System.Collections.Generic;
using System;

namespace BoxOfT
{
    class Box<T>
    {
        public int Count => this.list.Count;
        private List<T> list;

        public Box()
        {
            this.list = new List<T>();
        }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public T Remove()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The box is empty!");
            }
            T element = this.list[list.Count - 1];
            this.list.RemoveAt(list.Count - 1);
            return element;
        }
    }
}
