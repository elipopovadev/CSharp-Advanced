using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateCustomQueue
{
    public class CustomQueue : IEnumerable<int>
    {
        private const int InitialCapacity = 4;
        private int currentCapacity;
        public int[] elementsInQueue;

        public CustomQueue()
        {
            currentCapacity = InitialCapacity;
            this.elementsInQueue = new int[currentCapacity];
        }

        public CustomQueue(int capacity)
        {
            currentCapacity = capacity;
            this.elementsInQueue = new int[currentCapacity];
        }

        private void Validate()
        {
            if (this.Count == 0)
            {
                throw new Exception("The queue is empty!");
            }
        }

        public int Count { get; private set; }

        private int[] Resize()
        {
            int[] newArray = new int[2 * currentCapacity];
            this.currentCapacity = newArray.Length;
            int currentIndex = this.currentCapacity - 1;
            for (int k = this.Count - 1; k >= 0; k--)
            {
                newArray[currentIndex] = this.elementsInQueue[k];
                currentIndex--;
            }

            return newArray;
        }

        private int[] Shrink()
        {
            var newArray = new int[currentCapacity / 2];
            this.currentCapacity = newArray.Length;
            int currentIndex = this.currentCapacity - 1;
            for (int k = this.Count - 1; k >= 1; k--)
            {
                newArray[currentIndex] = this.elementsInQueue[k];
                currentIndex--;
            }

            return newArray;
        }

        public void Enqueue(int element)
        {
            if (this.Count == currentCapacity)
            {
                int[] newArray = Resize();
                int indexForNewElement = this.currentCapacity - this.Count - 1;
                newArray[indexForNewElement] = element;
                this.elementsInQueue = newArray;
                this.Count++;
            }

            else
            {
                int indexForNewElement = this.currentCapacity - this.Count - 1;
                this.elementsInQueue[indexForNewElement] = element;
                this.Count++;
            }
        }

        public int Dequeue()
        {
            Validate();
            int indexForFirstElement = this.currentCapacity - this.Count;
            int firstElement = this.elementsInQueue[indexForFirstElement];
            if (this.Count - 1 <= currentCapacity / 4)
            {
                Shrink();
                this.Count--;
                return firstElement;
            }
            this.Count--;
            this.elementsInQueue[indexForFirstElement] = default;
            return firstElement;
        }

        public int Peek()
        {
            Validate();
            int indexForFirstElement = this.currentCapacity - this.Count;
            int firstElement = this.elementsInQueue[indexForFirstElement];
            return firstElement;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int startIndex = this.currentCapacity - this.Count;
            for (int i = startIndex; i < currentCapacity; i++)
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
