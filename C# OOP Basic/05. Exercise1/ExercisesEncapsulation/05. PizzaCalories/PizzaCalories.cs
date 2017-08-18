using System;

namespace _05.PizzaCalories
{
    internal class PizzaCalories
    {
        private static void Main()
        {
            try
            {
                var input = Console.ReadLine();
                var startTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var order = startTokens[0];

                while (order != "END")
                {
                    switch (order)
                    {
                        case "Dough":
                            PrintDough(input);
                            break;

                        case "Topping":
                            PrintTopping(input);
                            break;

                        case "Pizza":
                            PrintPizza(input);
                            break;
                    }
                    input = Console.ReadLine();
                    startTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    order = startTokens[0];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintPizza(string input)
        {
            var pizzaData = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var pizzaName = pizzaData[1];
            var toppingsCount = int.Parse(pizzaData[2]);
            if (toppingsCount < 0 || toppingsCount > 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }

            var doughData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var flourType = doughData[1];
            var technique = doughData[2];
            var doughWeight = int.Parse(doughData[3]);

            Dough dough = new Dough(flourType, technique, doughWeight);

            Pizza pizza = new Pizza(pizzaName, dough);

            for (int i = 0; i < toppingsCount; i++)
            {
                var toppingTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var toppingType = toppingTokens[1];
                var toppingWeight = int.Parse(toppingTokens[2]);

                var topping = new Topping(toppingType, toppingWeight);

                pizza.AddTopping(topping);
            }
            Console.WriteLine(pizza.ToString());
        }

        private static void PrintTopping(string input)
        {
            var toppingTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var test2Topping = new Topping(toppingTokens[1], int.Parse(toppingTokens[2]));
            Console.WriteLine($"{test2Topping.CalculateCalories():F2}");
        }

        private static void PrintDough(string input)
        {
            var test1tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var test1Dough = new Dough(test1tokens[1], test1tokens[2], int.Parse(test1tokens[3]));
            Console.WriteLine($"{test1Dough.CalculateCalories():F2}");
        }
    }
}