using System;
using System.Text;

namespace CreateCustomList
{
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;
        private int[] elementsInTheList;
        private int currentCapacity;

        public CustomList()
        {
            elementsInTheList = new int[InitialCapacity];
            currentCapacity = InitialCapacity;
        }

        public CustomList(int capacity)
        {
            elementsInTheList = new int[capacity];
            currentCapacity = capacity;
        }

        public int Count { get; private set; }

        private void ShiftToRight(int index, int itemToInsert)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.elementsInTheList[i] = this.elementsInTheList[i - 1];
            }
            this.elementsInTheList[index] = itemToInsert;
        }

        private void Shrink()
        {
            int[] newArray = new int[currentCapacity / 2];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elementsInTheList[i];
            }
            currentCapacity = newArray.Length;
            this.elementsInTheList = newArray;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.elementsInTheList[i] = this.elementsInTheList[i + 1];
            }
            this.elementsInTheList[this.Count - 1] = 0;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new Exception("Index is invalid!");
            }
        }

        private void ResizeTheArray(int element)
        {
            int[] newArray = new int[2 * currentCapacity];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elementsInTheList[i];
            }
            this.Count++;
            currentCapacity = newArray.Length;
            this.elementsInTheList = newArray;
        }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.elementsInTheList[index];
            }
            set
            {
                ValidateIndex(index);
                this.elementsInTheList[index] = value;
            }
        }

        public void Add(int element)
        {
            if (this.Count + 1 > currentCapacity)
            {
                ResizeTheArray(element);
                this.elementsInTheList[this.Count - 1] = element;
            }

            else
            {
                this.Count++;
                this.elementsInTheList[this.Count - 1] = element;

            }
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            ShiftToLeft(index);
            this.Count--;
            if (this.Count <= this.elementsInTheList.Length / 4)
            {
                Shrink();
            }
        }

        public void Insert(int index, int item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new Exception("Index is invalid!");
            }

            if (index == this.Count)
            {
                Add(item); // call Resize
            }

            else if (this.Count + 1 > currentCapacity)
            {
                ResizeTheArray(item);
                ShiftToRight(index, item);
                this.Count++;
            }
            else
            {
                ShiftToRight(index, item);
                this.Count++;
            }
        }

        public bool Contains(int element)
        {
            foreach (var item in this.elementsInTheList)
            {
                if (item == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);
            var firstElement = this.elementsInTheList[firstIndex];
            this.elementsInTheList[firstIndex] = this.elementsInTheList[secondIndex];
            this.elementsInTheList[secondIndex] = firstElement;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
               string item = this.elementsInTheList[i].ToString();
               sb.Append(item + " ");
            }
           
            return sb.ToString().Remove(sb.Length - 1, 1);
        }
    }
}
