using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _06.Animals
{
    internal class Animals
    {
        private static void Main()
        {
            var animals = new List<Animal>();

            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Trim();

                    if (input.Equals("beast!", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    var animalType = input;
                    var type = Assembly.GetExecutingAssembly().GetTypes()
                        .FirstOrDefault(x => x.IsSubclassOf(typeof(Animal)) && x.Name.Equals(animalType));

                    var animalInfo = Console.ReadLine().Trim().Split();
                    var name = animalInfo[0];
                    var age = int.Parse(animalInfo[1]);
                    var gender = animalInfo[2];

                    var constructor = type.GetConstructor(new[] { typeof(string), typeof(int), typeof(string) });

                    var animal = (Animal)constructor.Invoke(new object[] { name, age, gender });

                    animals.Add(animal);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}