namespace KnightsOfHonor
{
    using System;

    internal class KnightsOfHonor
    {
        private static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> addTitleSir = n => Console.WriteLine($"Sir {n}");

            foreach (string name in input)
            {
                addTitleSir(name);
            }
        }
    }
}