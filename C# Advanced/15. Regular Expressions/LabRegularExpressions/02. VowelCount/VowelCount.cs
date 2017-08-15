namespace _02.VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    internal class VowelCount
    {
        private static void Main()
        {
            string text = Console.ReadLine();

            Regex pattern = new Regex(@"[aeiouyAEIOUY]");
            int count = pattern.Matches(text).Count;
            Console.WriteLine($"Vowels: {count}");
        }
    }
}