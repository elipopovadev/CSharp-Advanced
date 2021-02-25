using System;
namespace GenericCountMethodString
{
    class Box<T> : IComparable<Box<T>> where T : IComparable<T>
    {
        public Box(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }

        public int CompareTo(Box<T> otherBox)
        {
            if (this.Data.CompareTo(otherBox.Data) > 0)
            {
                return 1;
            }

            else if (this.Data.CompareTo(otherBox.Data) < 0)
            {
                return -1;
            }

            else // they are equal
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"{Data.GetType().FullName}: {this.Data}";
        }
    }
}
