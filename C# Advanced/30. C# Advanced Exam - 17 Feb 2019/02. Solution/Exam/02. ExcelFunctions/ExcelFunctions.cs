using System;
using System.Collections.Generic;
using System.Linq;

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
                    {
                        string header = commandItems[1];
                        int col = FilterCol(header);
                        SortTable(col);
                    }
                    break;

                case "hide":
                    {
                        string header = commandItems[1];
                        int col = FilterCol(header);
                        ClearTable(col);
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

        private static void SortTable(int colIndex)
        {
            Dictionary<int, string> saveInfo = new Dictionary<int, string>();

            for (int row = 1; row < n; row++)
            {
                saveInfo.Add(row, table[row, colIndex]);
            }

            saveInfo = saveInfo.OrderBy(p => p.Value).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine(string.Join(" | ", header));

            foreach (var item in saveInfo)
            {
                List<string> line = new List<string>();

                for (int col = 0; col < header.Length; col++)
                {
                    line.Add(table[item.Key, col]);
                }

                Console.WriteLine(string.Join(" | ", line));
            }
        }

        private static void ClearTable(int colIndex)
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                List<string> resultLine = new List<string>();

                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (col != colIndex)
                    {
                        resultLine.Add(table[row, col]);
                    }
                }

                Console.WriteLine(string.Join(" | ", resultLine));
            }
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

            for (int row = 1; row < n; row++)
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