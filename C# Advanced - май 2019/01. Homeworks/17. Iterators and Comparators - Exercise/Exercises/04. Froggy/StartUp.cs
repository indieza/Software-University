using System;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var numbers = new Lake(input);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}