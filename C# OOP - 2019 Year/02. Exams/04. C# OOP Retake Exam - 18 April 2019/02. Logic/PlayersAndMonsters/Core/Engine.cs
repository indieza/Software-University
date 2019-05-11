using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string line = Console.ReadLine();
            ManagerController controller = new ManagerController();

            while (line != "Report")
            {
                string[] items = line.Split();
                string result = string.Empty;

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

                    default:
                        break;
                }

                Console.WriteLine(result);
                line = Console.ReadLine();
            }
        }
    }
}