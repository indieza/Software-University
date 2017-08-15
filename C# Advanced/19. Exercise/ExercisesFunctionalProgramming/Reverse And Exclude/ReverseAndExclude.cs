namespace ReverseAndExclude
{
    using System;
    using System.Linq;

    internal class ReverseAndExclude
    {
        private static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divisor = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseArr = n => n.Reverse().ToArray();
            Predicate<int> canBeDivided = x => x % divisor == 0;

            nums = reverseArr.Invoke(nums);

            foreach (var number in nums)
            {
                if (!canBeDivided.Invoke(number))
                {
                    Console.Write(number + " ");
                }
            }

            Console.WriteLine();
        }
    }
}