using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    public class PrimaryDiagonal
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] nums = Console
                .ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        sum += nums[col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}