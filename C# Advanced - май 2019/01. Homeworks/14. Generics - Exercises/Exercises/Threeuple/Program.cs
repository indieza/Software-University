using System;

namespace Threeuple
{
    public class Program
    {
        private static void Main()
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();
            string[] input3 = Console.ReadLine().Split();

            var mishMash1 = new Tuple<string, string, string>(input1[0] + " " + input1[1], input1[2], input1[3]);
            var mishMash2 = new Tuple<string, int, string>(input2[0], int.Parse(input2[1]), input2[2] == "drunk" ? "True" : "False");

            var mishMash3 = new Tuple<string, double, string>(input3[0], double.Parse(input3[1]), input3[2]);

            Console.WriteLine($"{mishMash1.Item1} -> {mishMash1.Item2} -> {mishMash1.Item3}");
            Console.WriteLine($"{mishMash2.Item1} -> {mishMash2.Item2} -> {mishMash2.Item3}");
            Console.WriteLine($"{mishMash3.Item1} -> {mishMash3.Item2} -> {mishMash3.Item3}");
        }
    }
}