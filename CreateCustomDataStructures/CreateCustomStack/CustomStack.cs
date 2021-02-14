using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateCustomStack 
{
    class CustomStack : IEnumerable<int>
    {
        private const int InitialCapacity = 4;
        private int currentCapacity = InitialCapacity;      
        private int[] elementsInTheStack;

        public CustomStack()
        {
           this.elementsInTheStack = new int[InitialCapacity];
           this.currentCapacity = InitialCapacity;
        }

        public CustomStack(int currentCapacity)           
        {
            this.elementsInTheStack = new int[currentCapacity];
            this.currentCapacity = currentCapacity;
        }

        public int Count { get; private set; }

        private void ResizeTheArray()
        {
            int[] newArray = new int[currentCapacity * 2];
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
            int[] newArray = new int[currentCapacity / 2];
            for (int i = 0; i < this.Count - 1; i++)
            {
                newArray[i] = this.elementsInTheStack[i];
            }
            this.elementsInTheStack = newArray;
            this.currentCapacity = newArray.Length;
            this.Count--;
        }

        public void ValidateTheStack()
        {
            if (this.Count == 0)
            {
                throw new Exception("The stack is empty!");
            }
        }

        public void Push (int element)
        {
            if(this.Count + 1 > currentCapacity)
            {
                ResizeTheArray();
                this.elementsInTheStack[this.Count-1] = element;
            }
            else
            {
                this.Count++;
                this.elementsInTheStack[this.Count-1] = element;                                  
            }           
        }

        public int Pop()
        {
            ValidateTheStack();
            int lastElement = this.elementsInTheStack[this.Count - 1];
            if (this.Count-1 <= currentCapacity / 4)
            {
                Shrink();
                return lastElement;
            }
            else
            {
                this.Count--;
                this.elementsInTheStack[this.Count] = default;               
                return lastElement;
            }           
        }

        public int Peek()
        {
            ValidateTheStack();
            int lastElement = this.elementsInTheStack[this.Count - 1];
            return lastElement;
        }
       
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
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
