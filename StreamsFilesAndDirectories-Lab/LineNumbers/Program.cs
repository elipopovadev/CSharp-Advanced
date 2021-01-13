using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.CreateText("LineNum.txt"); 
        }
    }
}
