using System;
using System.Linq;
using System.Collections.Generic;

namespace TrojanInvasion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> platesList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Stack<int> warriorsStack = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                List<int> warriorsList = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                AddWarriors(warriorsStack, warriorsList);

                if (i % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    platesList.Add(additionalPlate);
                }

                while (warriorsStack.Count > 0 && platesList.Count > 0)
                {
                    int currentWarrior = warriorsStack.Pop();
                    int currentPlate = platesList[0];

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        warriorsStack.Push(currentWarrior);
                        platesList.RemoveAt(0);
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        currentPlate -= currentWarrior;
                        platesList[0] = currentPlate;
                    }
                    else
                    {
                        platesList.RemoveAt(0);
                    }
                }

                if (platesList.Count == 0)
                {
                    break;
                }
            }

            PrintOutput(platesList, warriorsStack);
        }

        private static void PrintOutput(List<int> platesList, Stack<int> warriorsStack)
        {
            if (platesList.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {String.Join(", ", warriorsStack)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {String.Join(", ", platesList)}");
            }
        }

        private static void AddWarriors(Stack<int> warriorsStack, List<int> warriorsList)
        {
            foreach (var war in warriorsList)
            {
                warriorsStack.Push(war);
            }
        }
    }
}
