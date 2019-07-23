namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private const string CommandPostfix = "Command";
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string line = Console.ReadLine();

            Console.WriteLine(this.commandInterpreter.Read(line));
        }
    }
}