namespace _02BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal class BlackBoxIntegerTests
    {
        private static void Main()
        {
            Type type = typeof(BlackBoxInt);
            BlackBoxInt blackBox = (BlackBoxInt)Activator.CreateInstance(type, true);

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] items = line.Split('_');
                string method = items[0];
                int value = int.Parse(items[1]);

                type.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(blackBox, new object[] { value });

                object state = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First()
                    .GetValue(blackBox);

                Console.WriteLine(state);

                line = Console.ReadLine();
            }
        }
    }
}