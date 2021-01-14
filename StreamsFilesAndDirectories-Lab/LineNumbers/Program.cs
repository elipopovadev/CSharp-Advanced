using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\Users\eli\Desktop\AllMyRepos\CSharp-Advanced\StreamsFilesAndDirectories-Lab\LineNumbers\input.txt"))
            {
                using(var writer = new StreamWriter(@"C:\Users\eli\Desktop\AllMyRepos\CSharp-Advanced\StreamsFilesAndDirectories-Lab\LineNumbers\output.txt"))
                {
                    int lineNumber = 1;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        writer.WriteLine($"{lineNumber}. {line}");
                        lineNumber++;
                    }
                }
            }
        }
    }
}
