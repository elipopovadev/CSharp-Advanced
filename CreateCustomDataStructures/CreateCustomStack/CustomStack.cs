using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateCustomStack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private int currentCapacity = InitialCapacity;
        private T[] elementsInTheStack;

        public CustomStack()
        {
            this.elementsInTheStack = new T[InitialCapacity];
            this.currentCapacity = InitialCapacity;
        }

        public CustomStack(int currentCapacity)
        {
            this.elementsInTheStack = new T[currentCapacity];
            this.currentCapacity = currentCapacity;
        }

        public int Count { get; private set; }

        private void ResizeTheArray()
        {
            T[] newArray = new T[currentCapacity * 2];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elementsInTheStack[i];
            }
            this.elementsInTheStack = newArray;
            this.currentCapacity = newArray.Length;
            this.Count++;
        }
        private void Shrink()
        {
            T[] newArray = new T[currentCapacity / 2];
            for (int i = 0; i < this.Count - 1; i++)
            {
                newArray[i] = this.elementsInTheStack[i];
            }
            this.elementsInTheStack = newArray;
            this.currentCapacity = newArray.Length;      
        }

        public void ValidateTheStack()
        {
            if (this.Count == 0)
            {
                throw new Exception("The stack is empty!");
            }
        }

        public void Push(T element)
        {
            if (this.Count + 1 > currentCapacity)
            {
                ResizeTheArray();
                this.elementsInTheStack[this.Count - 1] = element;
            }
            else
            {
                this.Count++;
                this.elementsInTheStack[this.Count - 1] = element;
            }
        }

        public T Pop()
        {
            ValidateTheStack();
            T lastElement = this.elementsInTheStack[this.Count - 1];
            if (this.Count - 1 <= currentCapacity / 4)
            {
                Shrink();
                this.Count--;
                return lastElement;
            }
            this.Count--;
            this.elementsInTheStack[this.Count] = default;
            return lastElement;
        }

        public T Peek()
        {
            ValidateTheStack();
            T lastElement = this.elementsInTheStack[this.Count - 1];
            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elementsInTheStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
