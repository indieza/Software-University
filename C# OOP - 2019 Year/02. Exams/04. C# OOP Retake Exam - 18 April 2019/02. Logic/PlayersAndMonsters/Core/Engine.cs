using PlayersAndMonsters.Core.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string line = Console.ReadLine();
            ManagerController controller = new ManagerController();

            while (line != "Exit")
            {
                string[] items = line.Split();
                string result = string.Empty;
                try
                {
                    switch (items[0])
                    {
                        case "AddPlayer":
                            result = controller.AddPlayer(items[1], items[2]);
                            break;

                        case "AddCard":
                            result = controller.AddCard(items[1], items[2]);
                            break;

                        case "AddPlayerCard":
                            result = controller.AddPlayerCard(items[1], items[2]);
                            break;

                        case "Fight":
                            result = controller.Fight(items[1], items[2]);
                            break;

                        case "Report":
                            result = controller.Report();
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                Console.WriteLine(result);
                line = Console.ReadLine();
            }
        }
    }
}