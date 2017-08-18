namespace _04.TheCommandsStrikeBack.Core
{
    using System;
    using Contracts;

    internal class Engine : IRunnable
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

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
                    string result = this.InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            commandName = char.ToUpper(commandName[0]) + commandName.Substring(1);
            var typeInfo = Type.GetType("_04.TheCommandsStrikeBack.Core.Commands." + commandName + "Command");

            if (typeInfo == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var instance = Activator.CreateInstance(typeInfo, data, this.repository, this.unitFactory);

            var executeMethod = instance.GetType().GetMethod("Execute");
            var result = executeMethod.Invoke(instance, new object[] { }) as string;

            return result;
        }

        private string ReportCommand(string[] data)
        {
            string output = this.repository.Statistics;
            return output;
        }

        private string AddUnitCommand(string[] data)
        {
            string unitType = data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}