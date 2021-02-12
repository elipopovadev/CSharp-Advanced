using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listWithPeople = new List<Person>();
            var listWithProducts = new List<Product>();
            string[] allPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < allPeople.Length; i++)
            {
                string[] currentPerson = allPeople[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string curretName = currentPerson[0];
                decimal currentMoney = decimal.Parse(currentPerson[1]);
                if (!listWithPeople.Any(p => p.Name == curretName))
                {
                    var newPerson = new Person(curretName, currentMoney);
                    listWithPeople.Add(newPerson);
                }
            }

            string[] allProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < allProducts.Length; i++)
            {
                string[] currentProduct = allProducts[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string currentProductName = currentProduct[0];
                decimal currentProductCost = decimal.Parse(currentProduct[1]);
                if (!listWithProducts.Any(pr => pr.Name == currentProductName))
                {
                    var newProduct = new Product(currentProductName, currentProductCost);
                    listWithProducts.Add(newProduct);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] infoAboutOrder = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string customer = infoAboutOrder[0];
                string product = infoAboutOrder[1];
                if (listWithPeople.Any(p => p.Name == customer) && listWithProducts.Any(pr => pr.Name == product))
                {
                    var findCustomer = listWithPeople.First(p => p.Name == customer);
                    var findProduct = listWithProducts.First(pr => pr.Name == product);
                    findCustomer.AddProduct(findProduct);
                }
            }

            foreach (var person in listWithPeople)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }


    public class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<Product> BagOfProducts { get; set; }

        public void AddProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.BagOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }

            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Name} - ");

            if (this.BagOfProducts.Count > 0)
            {
                foreach (var product in this.BagOfProducts)
                {
                    sb.Append($"{product.Name}, ");
                }

                sb.Remove(sb.Length - 2, 2);
            }

            else
            {
                sb.Append("Nothing bought");
            }

            return sb.ToString();
        }
    }


    public class Product
    {
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
