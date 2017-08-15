namespace _04.AddVat
{
    using System;
    using System.Linq;

    internal class AddVat
    {
        private static void Main()
        {
            Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).Select(n => n * 1.20m).ToList().ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}