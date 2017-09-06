using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class TreasureMap
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Regex pattern = new Regex(@"#([^#!]+)!|!([^!#]+)#");
        List<string> test = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string[] items = line.Split(new[] { '!', '#' }, StringSplitOptions.RemoveEmptyEntries);
            test.AddRange(items);
        }
    }
}