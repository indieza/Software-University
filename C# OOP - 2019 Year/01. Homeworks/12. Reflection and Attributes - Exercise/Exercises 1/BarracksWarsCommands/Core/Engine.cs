namespace _03BarracksFactory.Core
{
    using _03BarracksWarsCommands.Core.Commands;
    using Contracts;
    using System;
    using System.Globalization;
    using System.Reflection;

    internal class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            Type type = Type.GetType($"{typeof(Command).Namespace}" +
                                     $".{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName.ToLower()) + "Command"}");

            object instance = Activator
                .CreateInstance(type, new object[] { data, this.repository, this.unitFactory });

            try
            {
                MethodInfo info = type.GetMethod("Execute");
                string result = info.Invoke(instance, null).ToString();
                return result;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }
    }
}