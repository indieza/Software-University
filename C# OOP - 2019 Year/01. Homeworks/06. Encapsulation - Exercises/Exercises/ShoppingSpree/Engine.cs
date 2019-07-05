namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly List<Person> people;
        private readonly List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                string[] inputPeople = Console.ReadLine()
                    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                string[] inputProducts = Console.ReadLine()
                    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                AddPerson(inputPeople);
                AddProduct(inputProducts);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] information = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    string personName = information[0];
                    string productName = information[1];

                    Person targetPerson = this.people.FirstOrDefault(p => p.Name == personName);
                    Product targetProduct = this.products.FirstOrDefault(p => p.Name == productName);

                    if (targetProduct != null && targetPerson != null)
                    {
                        Console.WriteLine(targetPerson.AddProduct(targetProduct));
                    }

                    command = Console.ReadLine();
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddProduct(string[] productsInformation)
        {
            foreach (string productData in productsInformation)
            {
                string[] data = productData.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                string productName = data[0];
                decimal productCost = decimal.Parse(data[1]);

                Product person = new Product(productName, productCost);
                this.products.Add(person);
            }
        }

        private void AddPerson(string[] peopleInformation)
        {
            foreach (string personData in peopleInformation)
            {
                string[] data = personData.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                string personName = data[0];
                decimal personMoney = decimal.Parse(data[1]);

                Person person = new Person(personName, personMoney);
                this.people.Add(person);
            }
        }
    }
}