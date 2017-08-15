namespace _07.LegoBlock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class LegoBlock
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<List<int>> matrix = new List<List<int>>();
            List<int> row = new List<int>();

            for (int j = 1; j <= 2 * n; j++)
            {
                row = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();

                matrix.Add(row);
            }

            bool isFit = true;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i].Count + matrix[i + n].Count != matrix[i - 1].Count + matrix[i - 1 + n].Count)
                {
                    isFit = false;
                    break;
                }
            }

            if (isFit)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i + n].Reverse();
                    Console.WriteLine("[" + string.Join(", ", matrix[i]) + ", " +
                                      string.Join(", ", matrix[i + n].ToList()) + "]");
                }
            }
            else
            {
                int sum = 0;

                for (int i = 0; i < (2 * n); i++)
                {
                    sum += matrix[i].Count;
                }

                Console.WriteLine("The total number of cells is: {0}", sum);
            }
        }
    }
}