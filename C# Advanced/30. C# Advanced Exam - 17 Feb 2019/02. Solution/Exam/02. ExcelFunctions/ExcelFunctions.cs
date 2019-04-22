using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ExcelFunctions
{
    public class ExcelFunctions
    {
        private static int rows;
        private static int cols;
        private static string[,] table;
        private static string[] header;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            header = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            cols = header.Length;
            table = new string[rows, cols];

            FillTabel();

            string[] commandItems = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            switch (commandItems[0])
            {
                case "hide":
                    {
                        int col = ExecuteCol(commandItems[1]);
                        table = HideCol(col);
                        cols--;
                        PrintTable();
                    }
                    break;

                case "sort":
                    {
                        int col = ExecuteCol(commandItems[1]);
                        SortTable(col);
                    }
                    break;

                case "filter":
                    {
                        int col = ExecuteCol(commandItems[1]);
                        List<int> resultRows = ExecuteRow(col, commandItems[2]);
                        PrintFilteredRow(resultRows);
                    }
                    break;

                default:
                    break;
            }
        }

        private static void PrintFilteredRow(List<int> resultRows)
        {
            Console.WriteLine(string.Join(" | ", header));

            foreach (var row in resultRows)
            {
                List<string> info = new List<string>();

                for (int col = 0; col < cols; col++)
                {
                    info.Add(table[row, col]);
                }

                Console.WriteLine(string.Join(" | ", info));
            }
        }

        private static List<int> ExecuteRow(int col, string v)
        {
            List<int> resultRows = new List<int>();

            for (int row = 1; row < rows; row++)
            {
                if (table[row, col] == v)
                {
                    resultRows.Add(row);
                }
            }

            return resultRows;
        }

        private static void SortTable(int colIndex)
        {
            Dictionary<int, string> saveInfo = new Dictionary<int, string>();

            for (int row = 1; row < rows; row++)
            {
                saveInfo.Add(row, table[row, colIndex]);
            }

            saveInfo = saveInfo.OrderBy(p => p.Value).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine(string.Join(" | ", header));

            foreach (var item in saveInfo)
            {
                List<string> line = new List<string>();

                for (int col = 0; col < cols; col++)
                {
                    line.Add(table[item.Key, col]);
                }

                Console.WriteLine(string.Join(" | ", line));
            }
        }

        private static void PrintTable()
        {
            for (int row = 0; row < rows; row++)
            {
                List<string> items = new List<string>();

                for (int col = 0; col < cols; col++)
                {
                    items.Add(table[row, col]);
                }

                Console.WriteLine(string.Join(" | ", items));
            }
        }

        private static string[,] HideCol(int colIndex)
        {
            string[,] newTable = new string[rows, cols - 1];
            string[] newHeader = new string[header.Length - 1];

            for (int row = 0; row < rows; row++)
            {
                int saveCols = 0;

                for (int col = 0; col < cols; col++)
                {
                    if (col != colIndex)
                    {
                        newTable[row, saveCols] = table[row, col];
                        newHeader[saveCols] = header[col];
                        saveCols++;
                    }
                }
            }

            header = newHeader;
            return newTable;
        }

        private static int ExecuteCol(string key)
        {
            int resultCol = 0;

            for (int col = 0; col < cols; col++)
            {
                if (table[0, col] == key)
                {
                    resultCol = col;
                }
            }

            return resultCol;
        }

        private static void FillTabel()
        {
            for (int col = 0; col < cols; col++)
            {
                table[0, col] = header[col];
            }

            for (int row = 1; row < rows; row++)
            {
                string[] items = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    table[row, col] = items[col];
                }
            }
        }
    }
}