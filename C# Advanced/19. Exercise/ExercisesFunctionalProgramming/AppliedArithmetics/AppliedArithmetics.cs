namespace AppliedArithmetics
{
    using System;
    using System.Linq;

    internal class AppliedArithmetics
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            Func<int[], int[]> add = n => n.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtract = n => n.Select(x => x - 1).ToArray();

            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            while (!input.Equals("end"))
            {
                switch (input)
                {
                    case "add":
                        numbers = add.Invoke(numbers);
                        break;

                    case "multiply":
                        numbers = multiply.Invoke(numbers);
                        break;

                    case "subtract":
                        numbers = subtract.Invoke(numbers);
                        break;

                    case "print":
                        print.Invoke(numbers);
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}