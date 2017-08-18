using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    internal class ShoppingSpree
    {
        private static void Main()
        {
            try
            {
                string[] peoplesLine = Console.ReadLine().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string[] productsLine = Console.ReadLine().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                List<Product> products = new List<Product>();
                List<Person> peoples = new List<Person>();

                for (int i = 0; i < peoplesLine.Length; i++)
                {
                    string[] items = peoplesLine[i].Split('=');
                    string name = items[0];
                    decimal money = decimal.Parse(items[1]);

                    peoples.Add(new Person(name, money));
                }

                for (int i = 0; i < productsLine.Length; i++)
                {
                    string[] items = productsLine[i].Split('=');
                    string name = items[0];
                    decimal money = decimal.Parse(items[1]);

                    products.Add(new Product(name, money));
                }

                string line = Console.ReadLine();

                while (line != "END")
                {
                    string[] items = line.Split();
                    string personName = items[0];
                    string productName = items[1];

                    Person currentPerson = peoples.First(person => person.Name == personName);
                    Product currentProduct = products.First(product => product.Name == productName);

                    if (currentPerson.Money - currentProduct.Price >= 0)
                    {
                        currentPerson.Money -= currentProduct.Price;
                        currentPerson.Products.Add(currentProduct);
                        Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                    }

                    line = Console.ReadLine();
                }

                foreach (var person in peoples)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}