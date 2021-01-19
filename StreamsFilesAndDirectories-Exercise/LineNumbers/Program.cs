using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var reader=new StreamReader(@"..\..\..\input.txt"))
            {
                using (var writer = new StreamWriter(@"..\..\..\output.txt"))
                {
                    int lineCounter = 1;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var lineWithoutSpace = line.Replace(" ", "");
                        var charArray = lineWithoutSpace.ToCharArray();                      
                        int sumLetter = 0;
                        int sumPunctuationMarks = 0;
                        foreach (var symbol in charArray)
                        {
                            if (char.IsLetter(symbol))
                            {
                                sumLetter++;
                            }

                            else if(!char.IsLetter(symbol) && !char.IsDigit(symbol))
                            {
                                sumPunctuationMarks++;
                            }
                        }

                        writer.WriteLine($"Line {lineCounter}:{line}({sumLetter})({sumPunctuationMarks})");                       
                        lineCounter++;
                    }                 
                }
            }            
        }
    }
}
