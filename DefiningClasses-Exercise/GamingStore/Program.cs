using System;
using System.Collections.Generic;
using System.Linq;

namespace GamingStore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var validGames = new List<Game>()
            {
            new Game("OutFall 4", (decimal)39.99),

            new Game("CS: OG", (decimal)15.99),

            new Game("Zplinter Zell", (decimal)19.99),

            new Game("Honored 2", (decimal)59.99),

            new Game("RoverWatch", (decimal)29.99),

            new Game("RoverWatch Origins Edition", (decimal)39.99),
            };

            decimal initialCurrentBalance = decimal.Parse(Console.ReadLine());
            decimal myCurrentBalance = initialCurrentBalance;
            string command;
            while ((command = Console.ReadLine()) != "Game Time")
            {
                string gameName = command;
                if (validGames.Any(g => g.Name == gameName))
                {
                    var findGame = validGames.First(g => g.Name == gameName);
                    if (myCurrentBalance >= findGame.Price)
                    {
                        myCurrentBalance -= findGame.Price;
                        Console.WriteLine($"Bought {findGame.Name}");
                    }

                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                else
                {
                    Console.WriteLine("Not found");
                }

                if (myCurrentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }

            Console.WriteLine($"Total spent: ${(initialCurrentBalance - myCurrentBalance):F2}. Remaining: ${myCurrentBalance:F2}");
        }
    }

    public class Game
    {
        public Game(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
