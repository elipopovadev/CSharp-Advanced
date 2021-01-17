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
            var dictWordAppear = new Dictionary<string, int>();
            using (var readerWords = new StreamReader("words.txt"))
            {
                using (var readerText = new StreamReader("text.txt"))
                {

                    using (var writerInExpectedResult = new StreamWriter("output.txt"))
                    {
                        string[] wordsArray = readerWords.ReadToEnd().ToLower().Split();
                        while (!readerText.EndOfStream)
                        {
                            var lineArray = readerText.ReadLine().ToLower().Split(new char[] { ',', '.', '!', '?', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var wordInWordsArray in wordsArray)
                            {
                                foreach (var wordInLineArray in lineArray)
                                {
                                    if (string.Equals(wordInWordsArray, wordInLineArray))
                                    {
                                        if (!dictWordAppear.ContainsKey(wordInWordsArray))
                                        {
                                            dictWordAppear[wordInWordsArray] = 0;
                                        }

                                        dictWordAppear[wordInWordsArray]++;
                                    }
                                }
                            }
                        }

                        var sortedDict = dictWordAppear.OrderByDescending(x => x.Value);
                        foreach (var (word, appear) in sortedDict)
                        {
                            writerInExpectedResult.WriteLine($"{word}-{appear}");
                        }
                    }
                }
            }
        }
    }
}

