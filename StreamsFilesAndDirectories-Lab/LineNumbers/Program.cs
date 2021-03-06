﻿using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input.txt"))
            {
                using(var writer = new StreamWriter("output.txt"))
                {
                    int countlines = 1;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        writer.WriteLine($"{countlines}. {line}");
                        countlines++;
                    }
                }
            }
        }
    }
}
