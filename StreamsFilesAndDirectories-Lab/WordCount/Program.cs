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
            using (var readerWords = new StreamReader("words.txt"))
            {
                using (var writerInOutput = new StreamWriter("output.txt"))
                {
                    string[] wordsArray = readerWords.ReadToEnd().ToLower().Split(" ");

                    foreach (string wordInWords in wordsArray)
                    {
                        using (var readerText = new StreamReader("text.txt"))
                        {
                            while (!readerText.EndOfStream)
                            {
                                string[] textLine = readerText.ReadLine().ToLower().Split(new char[] {',',' ', '-', '.', '?', '!'});
                                foreach (string wordInText in textLine)
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
