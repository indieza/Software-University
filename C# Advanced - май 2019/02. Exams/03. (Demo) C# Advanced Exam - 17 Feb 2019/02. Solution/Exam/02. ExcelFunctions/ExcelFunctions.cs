using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.ExcelFunctions
{
    public class ExcelFunctions
    {
        private static int rows;
        private static string[][] table;
        private static string[] currentRow;
        private static string[] commandItems;
        private static string command;
        private static string header;
        private static string value;
        private static StringBuilder sb;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            table = new string[rows][];

            FillTable();
            ExecuteCommand();
        }

        private static void ExecuteCommand()
        {
            commandItems = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            command = commandItems[0];
            sb = new StringBuilder();

            switch (command)
            {
                case "hide":
                    header = commandItems[1];
                    HideCommand();
                    break;

                case "sort":
                    header = commandItems[1];
                    SortCommand();
                    break;

                case "filter":
                    header = commandItems[1];
                    value = commandItems[2];
                    FilterCommand();
                    break;

                default:
                    break;
            }
        }

        private static void SortCommand()
        {
            int index = ExecuteIndexOfColl();

            sb.AppendLine(string.Join(" | ", table[0]));

            foreach (var row in table.Skip(1).OrderBy(r => r[index]))
            {
                sb.AppendLine($"{string.Join(" | ", row)}");
            }

            PrintTable(sb);
        }

        private static void FilterCommand()
        {
            int index = ExecuteIndexOfColl();

            sb.AppendLine(string.Join(" | ", table[0]));

            for (int row = 0; row < table.GetLength(0); row++)
            {
                if (table[row][index] == value)
                {
                    sb.AppendLine(string.Join(" | ", table[row]));
                }
            }

            PrintTable(sb);
        }

        private static void HideCommand()
        {
            int index = ExecuteIndexOfColl();

            for (int row = 0; row < table.GetLength(0); row++)
            {
                List<string> line = new List<string>();

                for (int col = 0; col < table[0].Length; col++)
                {
                    if (col != index)
                    {
                        line.Add(table[row][col]);
                    }
                }

                sb.AppendLine(string.Join(" | ", line));
            }

            PrintTable(sb);
        }

        private static void PrintTable(StringBuilder sb)
        {
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static int ExecuteIndexOfColl()
        {
            int index = 0;

            for (int col = 0; col < table[0].Length; col++)
            {
                if (table[0][col] == header)
                {
                    index = col;
                }
            }

            return index;
        }

        private static void FillTable()
        {
            for (int row = 0; row < rows; row++)
            {
                currentRow = Console.ReadLine().Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                table[row] = currentRow;
            }
        }
    }
}