using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictWordCount = new Dictionary<string, int>();
            using (var readerWords = new StreamReader(@"C:\Users\eli\Desktop\AllMyRepos\CSharp-Advanced\StreamsFilesAndDirectories-Lab\WordCount\words.txt"))
            {
                using (var readerText = new StreamReader(@"C:\Users\eli\Desktop\AllMyRepos\CSharp-Advanced\StreamsFilesAndDirectories-Lab\WordCount\text.txt"))
                using (var writerInOutput = new StreamWriter(@"C:\Users\eli\Desktop\AllMyRepos\CSharp-Advanced\StreamsFilesAndDirectories-Lab\WordCount\output.txt"))
                {
                    string[] wordsArray = readerWords.ReadToEnd().ToLower().Split(" ");
                    string[] textArray = readerText.ReadToEnd().ToLower().Split(new char[]{',',' ','-','.','?','!'});
                    foreach (string wordInWords in  wordsArray)
                    {
                        foreach (string wordInText in textArray)
                        {
                            if (string.Equals(wordInWords, wordInText))
                            {
                                if (!dictWordCount.ContainsKey(wordInWords))
                                {
                                    dictWordCount[wordInWords] = 1;
                                }

                                else
                                {
                                    dictWordCount[wordInWords]++;
                                }                             
                            }
                        }
                    }

                    var sortedDict = dictWordCount.OrderByDescending(x => x.Value);
                    foreach (var (word, counter) in sortedDict)
                    {
                        writerInOutput.WriteLine($"{word}-{counter}");
                    }
                }
            }
        }
    }
}
