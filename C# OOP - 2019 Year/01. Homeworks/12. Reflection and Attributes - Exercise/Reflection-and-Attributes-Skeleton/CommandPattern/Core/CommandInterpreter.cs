namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostfix = "Command";

        public string Read(string args)
        {
            string[] commandItems = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandItems[0] + CommandPostfix;
            string[] items = commandItems.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] allTypes = assembly.GetTypes();
            Type type = allTypes.FirstOrDefault(t => t.Name == commandName);
            object instance = Activator.CreateInstance(type);

            ICommand command = (ICommand)instance;
            return command.Execute(items);
        }
    }
}