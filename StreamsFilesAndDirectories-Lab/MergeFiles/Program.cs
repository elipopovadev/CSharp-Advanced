using System;
using System.IO;
using System.Linq;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var readerInput1 = new StreamReader("input1.txt"))
            {
                using (var readerInput2 = new StreamReader("input2.txt"))
                {
                    var firstInput = readerInput1.ReadToEnd();
                    var secondInput = readerInput2.ReadToEnd();                
                    
                    using(var writerInOutput=new StreamWriter(@"C:\Users\eli\Desktop\AllMyRepos\CSharp-Advanced\StreamsFilesAndDirectories-Lab\MergeFiles\output.txt"))
                    {
                        
                    }
                }
            }
        }
    }
}
