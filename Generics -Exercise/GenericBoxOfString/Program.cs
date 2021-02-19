using System;
using System.IO;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfString = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfString; i++)
            {
                string data = Console.ReadLine();
                var newBox = new Box<string>(data);
                Console.WriteLine(newBox.ToString());
            }
        }
    }
}
