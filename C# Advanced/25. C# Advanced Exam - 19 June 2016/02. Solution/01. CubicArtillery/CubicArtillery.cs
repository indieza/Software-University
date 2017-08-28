using System;
using System.Collections.Generic;

internal class CubicArtillery
{
    private static void Main()
    {
        int capacity = int.Parse(Console.ReadLine());

        Queue<string> bunkers = new Queue<string>();
        Queue<int> weapons = new Queue<int>();

        string line = Console.ReadLine();
        int leftCapacity = capacity;

        while (line != "Bunker Revision")
        {
            string[] items = line.Split();

            foreach (string item in items)
            {
                int variable = 0;

                if (!int.TryParse(item, out variable))
                {
                    bunkers.Enqueue(item);
                }
                else
                {
                    int weaponCapacity = int.Parse(item);
                    bool isFind = false;

                    while (bunkers.Count > 1)
                    {
                        if (leftCapacity >= weaponCapacity)
                        {
                            weapons.Enqueue(weaponCapacity);
                            leftCapacity -= weaponCapacity;
                            isFind = true;
                            break;
                        }

                        Console.WriteLine(weapons.Count == 0
                            ? $"{bunkers.Dequeue()} -> Empty"
                            : $"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");

                        weapons.Clear();
                        leftCapacity = capacity;
                    }

                    if (!isFind)
                    {
                        if (capacity >= weaponCapacity)
                        {
                            while (leftCapacity < weaponCapacity)
                            {
                                leftCapacity += weapons.Dequeue();
                            }

                            leftCapacity -= weaponCapacity;
                            weapons.Enqueue(weaponCapacity);
                        }
                    }
                }
            }

            line = Console.ReadLine();
        }
    }
}