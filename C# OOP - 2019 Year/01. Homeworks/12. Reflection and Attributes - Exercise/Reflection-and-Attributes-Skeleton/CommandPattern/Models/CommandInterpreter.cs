namespace CommandPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using CommandPattern;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(a => a.Name == args);
            object classInstance = Activator.CreateInstance(type, null);

            MethodInfo methodInfo = type.GetMethod("Execute", BindingFlags.Public |
                BindingFlags.InvokeMethod |
                BindingFlags.Instance);

            //methodInfo.Invoke(classInstance, new object[] { });
            return "";
        }
    }
}