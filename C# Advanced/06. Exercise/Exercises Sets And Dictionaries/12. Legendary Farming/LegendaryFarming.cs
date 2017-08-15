namespace _12_Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class LegendaryFarming
    {
        private static void Main()
        {
            Dictionary<string, int> junkItems = new Dictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();

            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;

            bool itemObtained = false;

            while (!itemObtained)
            {
                string[] data = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < data.Length; i += 2)
                {
                    int quantity = int.Parse(data[i]);
                    string material = data[i + 1];

                    if (!keyMaterials.ContainsKey(material))
                    {
                        if (!junkItems.ContainsKey(material))
                        {
                            junkItems[material] = 0;
                        }

                        junkItems[material] += quantity;
                    }
                    else
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            switch (material)
                            {
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;

                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;

                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;
                            }

                            keyMaterials[material] -= 250;
                            itemObtained = true;

                            var keyMaterialsDescOrder = keyMaterials.OrderBy(x => x.Key)
                                .ThenByDescending(x => x.Value);

                            foreach (var item in keyMaterialsDescOrder)
                            {
                                Console.WriteLine("{0}: {1}", item.Key, item.Value);
                            }

                            var junkDescOrder = junkItems.OrderBy(x => x.Key);

                            foreach (var item in junkDescOrder)
                            {
                                Console.WriteLine("{0}: {1}", item.Key, item.Value);
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}