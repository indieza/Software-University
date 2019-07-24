namespace _01.Logger.Core
{
    using Contracts;
    using System;

    public class Engine:IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                var appendersArgs = Console.ReadLine().Split();

                this.commandInterpreter.AddAppender(appendersArgs);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input=="END")
                {
                    break;
                }

                var reportArgs = input.Split("|");
                this.commandInterpreter.AddReport(reportArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
