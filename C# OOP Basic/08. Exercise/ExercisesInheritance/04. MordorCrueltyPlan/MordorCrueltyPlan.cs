using System;

namespace _04.MordorCrueltyPlan
{
    internal class MordorCrueltyPlan
    {
        private static void Main()
        {
            var food = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var gandalf = new Gandalf();

            foreach (var s in food)
            {
                var f = FoodFactory.ProduceFood(s);
                gandalf.Eat(f);
            }

            Console.WriteLine(gandalf);
        }
    }
}