namespace SortEvenNumbers
{
    using System;
    using System.Linq;

    internal class SortEvenNumbers
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            int[] evenNumsSorted = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0).OrderBy(n => n).ToArray();

            Console.WriteLine(string.Join(", ", evenNumsSorted));
        }
    }
}