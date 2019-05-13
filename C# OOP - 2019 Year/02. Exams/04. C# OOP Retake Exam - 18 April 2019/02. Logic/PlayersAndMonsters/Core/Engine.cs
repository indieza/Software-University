using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.IO.IO;
using System.Reflection;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            ManagerController controller = new ManagerController();
            IReader reader = new Reader();
            IWriter writer = new Writer();

            string line = reader.ReadLine();

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
                catch (TargetInvocationException ex)
                {
                    writer.WriteLine(ex.InnerException.Message);
                }

                writer.WriteLine(result);
                line = reader.ReadLine();
            }
        }
    }
}