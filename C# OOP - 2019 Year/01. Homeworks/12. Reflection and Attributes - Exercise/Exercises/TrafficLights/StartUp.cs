using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TrafficLights
{
    public class StartUp
    {
        private static void Main()
        {
            List<string> lights = Console.ReadLine().Split().ToList();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                List<string> resultLights = new List<string>();

                for (int j = 0; j < lights.Count; j++)
                {
                    string currentLight = lights[j];

                    Type type = Type.GetType($"{typeof(Color).Namespace}.{currentLight}Light");
                    object instance = Activator.CreateInstance(type, new object[] { currentLight });
                    MethodInfo method = type.GetMethod("ChangeColor");
                    string result = method.Invoke(instance, null).ToString();
                    resultLights.Add(result);
                }

                Console.WriteLine(string.Join(" ", resultLights));
                lights = resultLights;
            }
        }
    }
}