using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\Users\eli\Desktop\AllMyRepos\CSharp-Advanced\StreamsFilesAndDirectories-Lab\OddLines\input.txt"))
            {
                using (var writer = new StreamWriter(@"C:\Users\eli\Desktop\AllMyRepos\CSharp-Advanced\StreamsFilesAndDirectories-Lab\OddLines\output.txt"))
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



