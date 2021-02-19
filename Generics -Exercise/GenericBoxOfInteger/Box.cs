namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T data)
        {
            this.Data = data;
        }

        public T Data { get; }

        public override string ToString()
        {
            return $"{Data.GetType().FullName}: {this.Data}";
        }
    }
}
