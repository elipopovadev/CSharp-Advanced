using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    static class Program
    {
        static void Main(string[] args)
        {
            var dictShopProductsPrices = new Dictionary<string, Dictionary<string, decimal>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Revision")
                {
                    break;
                }

                string[] inputArray = input.Split(", ");
                string shop = inputArray[0];
                string product = inputArray[1];
                decimal price = decimal.Parse(inputArray[2]);             
                if (!dictShopProductsPrices.ContainsKey(shop))
                {
                    dictShopProductsPrices[shop] = new Dictionary<string, decimal>();
                    dictShopProductsPrices[shop].Add(product, price);
                }

                else
                {
                    dictShopProductsPrices[shop][product]= price;
                }
            }

            foreach ( (var shop, var productsPrices) in dictShopProductsPrices.OrderBy(shop=> shop.Key))
            {
                Console.WriteLine($"{shop}->");
                foreach ( (var product, var price) in productsPrices)
                {
                    Console.WriteLine($"Product: {product}, Price: {price:F1}");
                }
            }

        }
    }
}
