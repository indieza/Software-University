using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    public class CountUppercaseWords
    {
        private static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            words = words.Where(w => w.ToCharArray()[0] >= 'A' && w.ToCharArray()[0] <= 'Z').ToArray();

            Console.WriteLine(string.Join("\n", words));
        }
    }
}