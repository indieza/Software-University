using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    public class JaggedArrayModification
    {
        private static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] array = new int[rows][];
            int cols = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console
                .ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                cols = nums.Length;

                array[row] = nums;
            }

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] items = line
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (items[0] == "Add")
                {
                    int row = int.Parse(items[1]);
                    int col = int.Parse(items[2]);

                    if (row < 0 || row >= rows || col < 0 || col >= cols)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        array[row][col] += int.Parse(items[3]);
                    }
                }
                else
                {
                    int row = int.Parse(items[1]);
                    int col = int.Parse(items[2]);

                    if (row < 0 || row >= rows || col < 0 || col >= cols)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        array[row][col] -= int.Parse(items[3]);
                    }
                }

                line = Console.ReadLine();
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", array[row]));
            }
        }
    }
}