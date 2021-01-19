using System;
using System.IO;
using System.Linq;

namespace SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using var readerInput= new FileStream("input.txt", FileMode.Open);
            var parts = 4;
            var length = (int)Math.Ceiling((decimal)readerInput.Length / parts);
            var buffer = new byte[length];

            for (int i = 0; i < parts; i++)
            {
                var bytesRead = readerInput.Read(buffer, 0, buffer.Length); // read the current bytes

                if (bytesRead < buffer.Length)
                {
                    buffer = buffer.Take(bytesRead).ToArray();
                }

                using var currentPartStream = new FileStream($"Part-{i + 1}.txt", FileMode.Open); // create a FileStream
                currentPartStream.Write(buffer, 0, buffer.Length); // write in a file
            }
        }
    }
}
