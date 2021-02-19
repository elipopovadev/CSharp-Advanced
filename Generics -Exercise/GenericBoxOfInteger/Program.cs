using System;

namespace GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                int data = int.Parse(Console.ReadLine());
                var newBox = new Box<int>(data);
                Console.WriteLine(newBox.ToString());
            }           
        }
    }
}
