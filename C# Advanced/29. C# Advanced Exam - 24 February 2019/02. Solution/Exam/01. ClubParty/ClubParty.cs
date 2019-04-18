using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.ClubParty
{
    public class ClubParty
    {
        private static readonly Regex AlphaPattern = new Regex(@"[a-zA-Z]");
        private static readonly Regex NumsPattern = new Regex(@"[0-9]");

        private static void Main()
        {
            int hallsCapacity = int.Parse(Console.ReadLine());
            string[] items = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> halls = new List<string>();
            List<int> capacity = new List<int>();

            string result = string.Empty;
            int saveCapacity = 0;
            bool fillRoom = false;

            for (int i = items.Length - 1; i >= 0; i--)
            {
                string item = items[i];

                if (AlphaPattern.IsMatch(item))
                {
                    halls.Add(item);
                }
                else if (NumsPattern.IsMatch(item))
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (fillRoom)
                        {
                            if (saveCapacity + int.Parse(item) <= hallsCapacity)
                            {
                                if (saveCapacity + int.Parse(item) == hallsCapacity)
                                {
                                    capacity.Add(int.Parse(item));
                                    Print(capacity, halls[0]);
                                    capacity.Clear();
                                    halls.RemoveAt(0);
                                    saveCapacity = 0;
                                }
                                else
                                {
                                    capacity.Add(int.Parse(item));
                                    saveCapacity += int.Parse(item);
                                }
                            }
                            else
                            {
                                Print(capacity, halls[0]);
                                capacity.Clear();
                                halls.RemoveAt(0);
                                saveCapacity = 0;

                                if (int.Parse(item) <= hallsCapacity)
                                {
                                    capacity.Add(int.Parse(item));
                                    saveCapacity += int.Parse(item);
                                }
                            }
                        }
                        else
                        {
                            capacity.Add(int.Parse(item));
                            saveCapacity += int.Parse(item);
                            fillRoom = true;
                        }
                    }
                }
            }
        }

        private static void Print(List<int> capacity, string hall)
        {
            Console.WriteLine($"{hall} -> {string.Join(", ", capacity)}");
        }
    }
}