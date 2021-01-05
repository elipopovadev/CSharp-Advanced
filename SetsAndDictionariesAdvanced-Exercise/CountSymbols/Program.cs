using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    static class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var dictSymbolTimes = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (!dictSymbolTimes.ContainsKey(symbol))
                {
                    dictSymbolTimes.Add(symbol, 1);
                }

                else
                {
                    dictSymbolTimes[symbol]++;
                }
            }

            foreach (var (symbol, times) in dictSymbolTimes.OrderBy(symbol => symbol.Key))
            {
                Console.WriteLine($"{symbol}: {times} time/s");
            }
        }
    }
}
