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

                switch (items[0])
                {
                    case "AddPlayer":
                        controller.AddPlayer(items[1], items[2]);
                        break;

                    case "AddCard":
                        controller.AddCard(items[1], items[2]);
                        break;

                    case "AddPlayerCard":
                        controller.AddPlayerCard(items[1], items[2]);
                        break;

                    case "Fight":
                        controller.Fight(items[1], items[2]);
                        break;

                    default:
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}