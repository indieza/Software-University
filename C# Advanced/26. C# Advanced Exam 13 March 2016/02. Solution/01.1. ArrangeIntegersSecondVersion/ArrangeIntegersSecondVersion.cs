using System;
using System.Linq;

internal class ArrangeIntegersSecondVersion
{
    private static readonly string[] Word = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    private static void Main()
    {
        Console.WriteLine(
            string.Join(", ", Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .OrderBy(str => string.Join(string.Empty, str.Select(ch => Word[ch - '0'])))));
    }
}