using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var reader= new StreamReader($"OddLines.txt"))
            {
                int counter = 0;
                using(var writer=new StreamWriter("OddLinesAnother.txt"))
                {
                    var line = reader.ReadLine();
                    if (counter % 2 != 0)
                    {
                        writer.WriteLine(line);
                    }

                    counter++;
                }
            }
        }
    }
}
