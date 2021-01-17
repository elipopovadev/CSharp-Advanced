using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileInfo = new Dictionary<string, Dictionary<string, double>>();
            DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\..\");
            var files = directoryInfo.GetFiles();
            foreach (var file in files)
            {
                if (!fileInfo.ContainsKey(file.Extension))
                {
                    fileInfo[file.Extension] = new Dictionary<string, double>();
                }

                fileInfo[file.Extension].Add(file.Name, file.Length / 1024.00);
            }

            using (var writerInReport = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt"),true))

            {
                foreach (var (extension, nameLength) in fileInfo.OrderByDescending(f => f.Value.Count()).ThenBy(x => x.Key))
                {
                    writerInReport.WriteLine(extension);
                    foreach (var (name, length) in nameLength.OrderBy(f => f.Value))
                    {
                        writerInReport.WriteLine($"--{name} - {length:F3}kb");
                    }
                }
            }
        }
    }
}





