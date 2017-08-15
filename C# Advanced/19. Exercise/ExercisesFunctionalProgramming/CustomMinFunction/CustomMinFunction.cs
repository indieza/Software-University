namespace CustomMinFunction
{
    using System;
    using System.Linq;

    internal class CustomMinFunction
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> findMin = n => n.Min();
            Console.WriteLine(findMin(numbers));
        }
    }
}