namespace GenericArrayCreator
{
    public  class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] newArray = new T[length];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = item;
            }

            return newArray;
        }
    }
}
