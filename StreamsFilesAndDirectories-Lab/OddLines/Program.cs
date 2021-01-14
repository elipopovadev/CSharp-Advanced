using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int counter = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}



