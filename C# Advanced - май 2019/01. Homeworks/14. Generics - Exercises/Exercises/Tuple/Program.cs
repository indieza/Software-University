using System;

namespace Tuple
{
    public class Program
    {
        private static void Main()
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();
            string[] input3 = Console.ReadLine().Split();
            var mishMash = new Tuple<string, string, string, string, int, int, double>
                (input1[0], input1[1], input1[2], input2[0], int.Parse(input2[1]), int.Parse(input3[0]), double.Parse(input3[1]));

            Console.WriteLine($"{mishMash.Item1} {mishMash.Item2} -> {mishMash.Item3}");
            Console.WriteLine($"{mishMash.Item4} -> {mishMash.Item5}");
            Console.WriteLine($"{mishMash.Item6} -> {mishMash.Item7}");
        }
    }
}