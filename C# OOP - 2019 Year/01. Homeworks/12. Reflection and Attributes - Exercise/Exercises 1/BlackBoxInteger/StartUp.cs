using System;
using System.Reflection;

namespace BlackBoxInteger
{
    public class StartUp
    {
        private static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            BlackBoxInteger classInstance = (BlackBoxInteger)Activator.CreateInstance(type, true);

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] items = command.Split("_");

                string methodName = items[0];
                int value = int.Parse(items[1]);

                MethodInfo methods = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

                methods.Invoke(classInstance, new object[] { value });
                object result =
                    type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(classInstance);

                Console.WriteLine(result);

                command = Console.ReadLine();
            }
        }
    }
}