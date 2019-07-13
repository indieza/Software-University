namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly ManagerController controller;

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
                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            result += controller.AddPlayer(commandItems[1], commandItems[2]);
                            break;

                        case "AddCard":
                            result += controller.AddCard(commandItems[1], commandItems[2]);
                            break;

                        case "AddPlayerCard":
                            result += controller.AddPlayerCard(commandItems[1], commandItems[2]);
                            break;

                        case "Fight":
                            result += controller.Fight(commandItems[1], commandItems[2]);
                            break;

                        case "Report":

                            result += controller.Report();
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    result += ex.Message;
                }

                Console.WriteLine(result);
                line = Console.ReadLine();
            }
        }
    }
}