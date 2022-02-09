using System;
using System.Linq;
using System.Collections.Generic;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var liquids = new Queue<int>(firstLine);
            var ingredients = new Stack<int>(secondLine);

            int countBread = 0;
            int countCake = 0;
            int countPastry = 0;
            int countFruitPie = 0;
            while(liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Peek();
                int currentIngredients = ingredients.Peek();
                int sum = currentLiquid + currentIngredients;
                if(sum == 25)
                {
                    RemoveFirstLiquidAndLastIngredients(liquids, ingredients);
                    countBread++;
                }

                else if(sum == 50)
                {
                    RemoveFirstLiquidAndLastIngredients(liquids, ingredients);
                    countCake++;
                }

                else if (sum == 75)
                {
                    RemoveFirstLiquidAndLastIngredients(liquids, ingredients);
                    countPastry++;
                }

                else if (sum == 100)
                {
                    RemoveFirstLiquidAndLastIngredients(liquids, ingredients);
                    countFruitPie++;
                }

                else
                {
                    RemoveFirstLiquidAndLastIngredients(liquids, ingredients);
                    int newIngredients = currentIngredients + 3;
                    ingredients.Push(newIngredients);
                }
            }

            if(countBread > 0 && countCake > 0 && countPastry > 0 && countFruitPie > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
                PrintResult(liquids, ingredients, countBread, countCake, countPastry, countFruitPie);
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
                PrintResult(liquids, ingredients, countBread, countCake, countPastry, countFruitPie);
            }
        }


        private static void RemoveFirstLiquidAndLastIngredients(Queue<int> liquids, Stack<int> ingredients)
        {
            liquids.Dequeue();
            ingredients.Pop();
        }

        private static void PrintResult(Queue<int> liquids, Stack<int> ingredients, int countBread, int countCake, int countPastry, int countFruitPie)
        {
            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine($"Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine($"Ingredients left: none");
            }

            Console.WriteLine($"Bread: {countBread}");
            Console.WriteLine($"Cake: {countCake}");
            Console.WriteLine($"Fruit Pie: {countFruitPie}");
            Console.WriteLine($"Pastry: {countPastry}");
        }
    }
}
