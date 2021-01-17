using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @"F:\C#\ZipFileDemoC#Advanced";
            string zipPath = @"F:\C#\ZipFileDemoCreateZip\result.zip"; // result.zip
            string extractPath = @"F:\C#\ZipFileDemoExtractZip\";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);       
        }
    }
}
