using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExcelFunctions
{
    public class ExcelFunctions
    {
        private static int n = 0;
        private static string[] items;
        private static string[,] table;
        private static void Main()
        {
            n = int.Parse(Console.ReadLine());
            items = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            table = new string[n, items.Length];

            FillFirstRoll();
            FillTable();

            string[] commandItems = Console.ReadLine().Split();
        }

        private static void FillFirstRoll()
        {
            for (int col = 0; col < items.Length; col++)
            {
                table[0, col] = items[col];
            }
        }

        private static void FillTable()
        {
            for (int row = 1; row < n; row++)
            {
                string[] info = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < items.Length; col++)
                {
                    table[row, col] = info[col];
                }
            }
        }
    }
}