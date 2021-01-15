using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"..\..\..\TestFolder");
            long sum = 0;
            foreach (var file in files)
            {
                var currentFileLength= new FileInfo(file).Length;
                sum += currentFileLength;
            }

            double size= (double) sum/ 1024 * 1024;
            File.WriteAllText(@"..\..\..\Result.txt", size.ToString());
        }
    }
}
