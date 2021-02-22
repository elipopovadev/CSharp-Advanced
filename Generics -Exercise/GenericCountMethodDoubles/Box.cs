using System;

namespace GenericCountMethodDoubles
{
    class Box<T> : IComparable<Box<T>> where T: IComparable<T>
    {
        public Box(T data)
        {
            this.Data = data;
        }

        public T Data { get; }

        public int CompareTo(Box<T> otherBox)
        {
            return this.Data.CompareTo(otherBox.Data);          
        }

        public override string ToString()
        {
            return $"{Data.GetType().FullName}: {this.Data}";
        }
    }
}
