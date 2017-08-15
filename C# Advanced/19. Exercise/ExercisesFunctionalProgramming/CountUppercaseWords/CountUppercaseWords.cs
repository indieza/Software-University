namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    internal class CountUppercaseWords
    {
        private static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> checkUpperCase = w => w[0].Equals(w.ToUpper()[0]);

            words.Where(checkUpperCase)
               .ToList()
               .ForEach(Console.WriteLine);
        }
    }
}