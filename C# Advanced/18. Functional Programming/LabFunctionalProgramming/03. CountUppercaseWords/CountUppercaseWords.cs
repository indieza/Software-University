namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;

    internal class CountUppercaseWords
    {
        private static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            bool IsUpper(string n) => n[0] == n.ToUpper()[0];

            words.Where(IsUpper).ToList().ForEach(Console.WriteLine);
        }
    }
}