namespace InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class InfernoIII
    {
        private static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            List<string> commands = new List<string>();

            while (!input.Equals("Forge"))
            {
                string[] args = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                string filterType = args[1];
                int parameter = int.Parse(args[2]);

                if (command.Equals("Exclude"))
                {
                    commands.Add(filterType + "," + parameter);
                }
                else if (command.Equals("Reverse"))
                {
                    if (commands.Contains(filterType + "," + parameter))
                    {
                        commands.Remove(filterType + "," + parameter);
                    }
                }

                input = Console.ReadLine();
            }

            List<int> markedNums = new List<int>();

            for (int i = 0; i < commands.Count; i++)
            {
                string[] args = commands[i].Split(',');
                string command = args[0];

                int param = int.Parse(args[1]); // eg. 9
                Func<int, int, bool> checkerLeftOrRight = (x, y) => x + y == param;
                Func<int, int, int, bool> checkerLeftAndRight = (x, y, z) => x + y + z == param;

                List<int> numsToBeMarked = new List<int>();

                switch (command)
                {
                    case "Sum Left":

                        numsToBeMarked = SumLeft(numbers, checkerLeftOrRight);
                        break;

                    case "Sum Right":

                        numsToBeMarked = SumRight(numbers, checkerLeftOrRight);
                        break;

                    case "Sum Left Right":

                        numsToBeMarked = SumLeftRight(numbers, checkerLeftAndRight);
                        break;
                }

                markedNums.AddRange(numsToBeMarked);
            }

            foreach (int markedNum in markedNums)
            {
                numbers.Remove(markedNum);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> SumLeft(List<int> gems, Func<int, int, bool> checker)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                var leftNum = i == 0 ? 0 : gems[i - 1];

                int currentNum = gems[i];

                if (checker(leftNum, currentNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }

        private static List<int> SumRight(List<int> gems, Func<int, int, bool> checker)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                int rightNum;

                if (i == gems.Count - 1)
                {
                    rightNum = 0;
                }
                else
                {
                    rightNum = gems[i + 1];
                }

                int currentNum = gems[i];

                if (checker(currentNum, rightNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }

        private static List<int> SumLeftRight(List<int> gems, Func<int, int, int, bool> checker)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                int leftNum;
                int rightNum;

                if (i == 0)
                {
                    leftNum = 0;
                }
                else
                {
                    leftNum = gems[i - 1];
                }

                rightNum = i == gems.Count - 1 ? 0 : gems[i + 1];

                int currentNum = gems[i];

                if (checker(leftNum, currentNum, rightNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }
    }
}