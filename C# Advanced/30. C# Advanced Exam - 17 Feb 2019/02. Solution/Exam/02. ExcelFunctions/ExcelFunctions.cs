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
        private static string[] header;
        private static string[,] table;
        private static void Main()
        {
            n = int.Parse(Console.ReadLine());
            header = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            table = new string[n, header.Length];

            FillFirstRoll();
            FillTable();

            string[] commandItems = Console.ReadLine().Split();

            switch (commandItems[0])
            {
                case "sort":
                    break;
                case "hide":
                    {
                        string header = commandItems[1];
                        int col = FilterCol(header);
                        RemoveCol(col);
                    }
                    break;
                case "filter":
                    {
                        string header = commandItems[1];
                        string value = commandItems[2];
                        int col = FilterCol(header);
                        int row = FilterRow(col, value);
                        PrintFilteredRow(row);
                    }
                    break;
                default:
                    break;
            }
        }

        private static void RemoveCol(int colIndex)
        {
            RemoveHeaderCol(colIndex);

            for (int row = 0; row < n; row++)
            {
                table[row, colIndex] = string.Empty;
            }

            List<string> newRow = new List<string>();
            // --------------------------------------------------Here

        }

        private static void RemoveHeaderCol(int colIndex)
        {
            header[colIndex] = string.Empty;
            List<string> newHeader = new List<string>();

            for (int col = 0; col < header.Length; col++)
            {
                if (!(header[col] == string.Empty))
                {
                    newHeader.Add(header[col]);
                }
            }

            header = newHeader.ToArray();
        }

        private static void PrintFilteredRow(int row)
        {
            Console.WriteLine(string.Join(" | ", header));
            List<string> info = new List<string>();

            for (int col = 0; col < table.GetLength(1); col++)
            {
                info.Add(table[row, col]);
            }

            Console.WriteLine(string.Join(" | ", info));
        }

        private static int FilterRow(int col, string value)
        {
            int rowResult = 0;

            for (int row = 0; row < n; row++)
            {
                if (table[row, col] == value)
                {
                    rowResult = row;
                }
            }

            return rowResult;
        }

        private static int FilterCol(string header)
        {
            int colResult = 0;

            for (int col = 0; col < table.GetLength(1); col++)
            {
                if (table[0, col] == header)
                {
                    colResult = col;
                }
            }

            return colResult;
        }

        private static void FillFirstRoll()
        {
            for (int col = 0; col < header.Length; col++)
            {
                table[0, col] = header[col];
            }
        }

        private static void FillTable()
        {
            for (int row = 1; row < n; row++)
            {
                string[] info = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < header.Length; col++)
                {
                    table[row, col] = info[col];
                }
            }
        }
    }
}