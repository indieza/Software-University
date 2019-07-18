namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly IManagerController controller;

        public Engine()
        {
            this.controller = new ManagerController();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "Exit")
            {
                string[] commandItems = line.Split();
                string command = commandItems[0];

                try
                {
                    string result = string.Empty;

                    switch (command)
                    {
                        case "AddPlayer":
                            result += this.controller.AddPlayer(commandItems[1], commandItems[2]);
                            break;

                        case "AddCard":
                            result += this.controller.AddCard(commandItems[1], commandItems[2]);
                            break;

                        case "AddPlayerCard":
                            result += this.controller.AddPlayerCard(commandItems[1], commandItems[2]);
                            break;

                        case "Fight":
                            result += this.controller.Fight(commandItems[1], commandItems[2]);
                            break;

                        case "Report":
                            result += this.controller.Report();
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }
        }
    }
}