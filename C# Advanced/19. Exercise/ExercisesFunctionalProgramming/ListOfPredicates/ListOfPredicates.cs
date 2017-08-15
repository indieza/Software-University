namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ListOfPredicates
    {
        private static void Main()
        {
            int endRange = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, bool>[] predicates = divisors
                .Select(d => (Func<int, bool>)(n => n % d == 0))
                .ToArray();

            List<int> result = new List<int>();

            for (int i = 1; i <= endRange; i++)
            {
                bool canBeDivided = true;
                foreach (Func<int, bool> predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        canBeDivided = false;
                        break;
                    }
                }

                if (canBeDivided)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}