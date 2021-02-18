using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateCustomQueue
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private int currentCapacity;
        public T[] elementsInQueue;

        public CustomQueue()
        {
            currentCapacity = InitialCapacity;
            this.elementsInQueue = new T[currentCapacity];
        }

        public CustomQueue(int capacity)
        {
            currentCapacity = capacity;
            this.elementsInQueue = new T[currentCapacity];
        }

        private void Validate()
        {
            if (this.Count == 0)
            {
                throw new Exception("The queue is empty!");
            }
        }

        public int Count { get; private set; }

        private T[] Resize()
        {
            T[] newArray = new T[2 * currentCapacity];
            this.currentCapacity = newArray.Length;
            this.elementsInQueue.CopyTo(newArray, 0);
            return newArray;
        }

        private T[] Shrink()
        {
            T[] newArray = new T[currentCapacity / 2];
            this.currentCapacity = newArray.Length;
            for (int i = 0; i < this.Count-1; i++)
            {
                newArray[0] = this.elementsInQueue[i + 1];
            }
            this.elementsInQueue = newArray;
            return newArray;
        }

        public void Enqueue(T element)
        {
            if (this.Count == currentCapacity)
            {
                T[] newArray = Resize();
                newArray[this.Count] = element;
                this.elementsInQueue = newArray;
                this.Count++;
            }

            else
            {
               
                this.elementsInQueue[this.Count] = element;
                this.Count++;
            }
        }

        public T Dequeue()
        {
            Validate();
            T firstElement = this.elementsInQueue[0];
            if (this.Count - 1 <= currentCapacity / 4)
            {
                Shrink();
                this.Count--;
                return firstElement;
            }
  
            for (int i = 0; i < this.Count-1; i++)
            {
                this.elementsInQueue[i] = this.elementsInQueue[i + 1];
            }
            this.Count--;
            return firstElement;
        }

        public T Peek()
        {
            Validate();
            T firstElement = this.elementsInQueue[0];
            return firstElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elementsInQueue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
