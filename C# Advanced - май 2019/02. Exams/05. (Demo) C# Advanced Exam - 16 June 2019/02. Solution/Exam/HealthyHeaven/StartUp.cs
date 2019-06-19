using System;

namespace HealthyHeaven
{
    public class StartUp
    {
        private static void Main()
        {
            // Initialize the repository
            Restaurant restaurant = new Restaurant("Casa Domingo");

            // Initialize the entities
            Vegetable tomato = new Vegetable("Tomato", 20);
            Vegetable cucumber = new Vegetable("Cucumber", 15);

            Salad salad = new Salad("Tomatoes with cucumbers");

            salad.Add(tomato);
            salad.Add(cucumber);

            Console.WriteLine(salad.GetTotalCalories()); // 35
            Console.WriteLine(salad.GetProductCount());  // 2

            Console.WriteLine(salad.ToString());
            // * Salad Tomatoes with cucumbers is 35 calories and have 2 products:
            //  - Tomato have 20 calories
            //  - Cucumber have 15 calories

            restaurant.Add(salad);

            Console.WriteLine(restaurant.Buy("Invalid salad")); // False

            // Initialize the second entities
            Vegetable corn = new Vegetable("Corn", 90);
            Salad casaDomingo = new Salad("Casa Domingo");

            casaDomingo.Add(tomato);
            casaDomingo.Add(cucumber);
            casaDomingo.Add(corn);

            restaurant.Add(casaDomingo);

            Console.WriteLine(restaurant.GetHealthiestSalad()); // Tomatoes with cucumbers

            Console.WriteLine(restaurant.GenerateMenu());
            // Casa Domingo have 2 salads:
            // * Salad Tomatoes with cucumbers is 35 calories and have 2 products:
            //  - Tomato have 20 calories
            //  - Cucumber have 15 calories
            // * Salad Casa Domingo is 125 calories and have 3 products:
            //  - Tomato have 20 calories
            //  - Cucumber have 15 calories
            //  - Corn have 90 calories
        }
    }
}