namespace CollectResources
{
    using System;
    using System.Collections.Generic;

    public class CollectResources
    {
        private static ISet<string> validResources = new HashSet<string>()
            {
                "stone", "gold", "wood", "food"
            };
        private static bool[] cellsVisited;
        private static string[] resourceField;

        public static void Main()
        {
            resourceField = Console.ReadLine().Split();
            int N = int.Parse(Console.ReadLine());
            int bestQuantity = 0;

            for (int i = 1; i <= N; i++)
            {
                cellsVisited = new bool[resourceField.Length];
                string[] path = Console.ReadLine().Split();
                int start = int.Parse(path[0]);
                int step = int.Parse(path[1]);

                int currentQuantity = TryGetResource(start);
                int currentIndex = (start + step) % resourceField.Length;
                while (!cellsVisited[currentIndex])
                {
                    currentQuantity += TryGetResource(currentIndex);
                    currentIndex = (currentIndex + step) % resourceField.Length;
                }

                if (currentQuantity > bestQuantity)
                {
                    bestQuantity = currentQuantity;
                }
            }

            Console.WriteLine(bestQuantity);
        }

        private static int TryGetResource(int index)
        {
            string[] resourceTokens = resourceField[index].Split('_');
            string resource = resourceTokens[0];

            if (validResources.Contains(resource))
            {
                cellsVisited[index] = true;
                return resourceTokens.Length > 1 ? int.Parse(resourceTokens[1]) : 1;
            }

            return 0;
        }
    }
}
