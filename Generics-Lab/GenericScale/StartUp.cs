using System;

namespace GenericScale
{
   public class StartUp
    {
        static void Main(string[] args)
        {
           var scale= new EqualityScale<string>("El", "El");
            Console.WriteLine(scale.AreEqual());

            var scalesecond = new EqualityScale<int>(10, 10);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
