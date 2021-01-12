using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines("OddLinesFile.rtf");
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 != 2)
                {
                    File.Copy(text[i], "OddLinesAnotherFile.rtf");
                }                                 
            }            
        }
    }
}
