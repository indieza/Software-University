namespace _04_Count_Symbols
{
    using System;
    using System.Collections.Generic;

    internal class CountSymbols
    {
        private static void Main()
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> counts = new SortedDictionary<char, int>();

            foreach (char ch in text)
            {
                if (counts.ContainsKey(ch))
                {
                    counts[ch]++;
                }
                else
                {
                    counts[ch] = 1;
                }
            }

            foreach (var pair in counts)
            {
                Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
            }
        }
    }
}