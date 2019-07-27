namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly IManagerController managerController;

        public Engine()
        {
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "Exit")
            {
                string[] commandItems = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string result = string.Empty;

                try
                {
                    switch (commandItems[0])
                    {
                        case "AddPlayer":
                            result += this.managerController.AddPlayer(commandItems[1], commandItems[2]);
                            break;

                        case "AddCard":
                            result += this.managerController.AddCard(commandItems[1], commandItems[2]);
                            break;

                        case "AddPlayerCard":
                            result += this.managerController.AddPlayerCard(commandItems[1], commandItems[2]);
                            break;

                        case "Fight":
                            result += this.managerController.Fight(commandItems[1], commandItems[2]);
                            break;

                        case "Report":
                            result += this.managerController.Report();
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