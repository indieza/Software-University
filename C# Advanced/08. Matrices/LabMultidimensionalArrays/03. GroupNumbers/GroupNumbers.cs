namespace _03.GroupNumbers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class GroupNumbers
    {
        private static void Main()
        {
            int[] numbers = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

            int[] sizes = new int[3];

            foreach (var number in numbers)
            {
                int reminder = Math.Abs(number % 3);
                sizes[reminder]++;
            }

            int[][] matrix =
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]]
            };

            int[] offsets = new int[3];

            foreach (var number in numbers)
            {
                int reminder = Math.Abs(number % 3);
                int index = offsets[reminder];
                matrix[reminder][index] = number;
                offsets[reminder]++;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                int[] innerArray = matrix[i];

                for (int a = 0; a < innerArray.Length; a++)
                {
                    Console.Write(innerArray[a] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}