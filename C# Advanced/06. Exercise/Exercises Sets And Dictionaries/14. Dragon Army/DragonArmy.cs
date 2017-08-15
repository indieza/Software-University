namespace _14_Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class DragonArmy
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, int[]>> dragonStats =
                new Dictionary<string, Dictionary<string, int[]>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string dragonType = data[0];
                string dragonName = data[1];
                int dragonDamage = 45;
                int dragonHealth = 250;
                int dragonArmor = 10;

                if (data[2] != "null")
                {
                    dragonDamage = int.Parse(data[2]);
                }

                if (data[3] != "null")
                {
                    dragonHealth = int.Parse(data[3]);
                }

                if (data[4] != "null")
                {
                    dragonArmor = int.Parse(data[4]);
                }

                int[] currentStats = { dragonDamage, dragonHealth, dragonArmor };

                if (!dragonStats.ContainsKey(dragonType))
                {
                    dragonStats[dragonType] = new Dictionary<string, int[]>();
                }

                if (!dragonStats[dragonType].ContainsKey(dragonName))
                {
                    dragonStats[dragonType][dragonName] = new int[3];
                }

                dragonStats[dragonType][dragonName] = currentStats;
            }

            foreach (var dragonTypePair in dragonStats)
            {
                Console.WriteLine("{0}::({1:f2}/{2:f2}/{3:f2})",
                    dragonTypePair.Key,
                    dragonTypePair.Value.Select(x => x.Value[0]).Average(),
                    dragonTypePair.Value.Select(x => x.Value[1]).Average(),
                    dragonTypePair.Value.Select(x => x.Value[2]).Average());

                foreach (var dragon in dragonTypePair.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}",
                        dragon.Key,
                        dragon.Value[0],
                        dragon.Value[1],
                        dragon.Value[2]);
                }
            }
        }
    }
}