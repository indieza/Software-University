namespace _04.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class AcademyGraduation
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var studets = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var studentName = Console.ReadLine();
                var marks = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToList();

                if (!studets.ContainsKey(studentName))
                {
                    studets[studentName] = marks;
                }
            }

            foreach (var studet in studets)
            {
                Console.WriteLine($"{studet.Key} is graduated with {studet.Value.Sum() / studet.Value.Count}");
            }
        }
    }
}