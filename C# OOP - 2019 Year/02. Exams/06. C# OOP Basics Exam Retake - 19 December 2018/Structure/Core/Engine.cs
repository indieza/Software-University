namespace SoftUniRestaurant.Core
{
    using System;

    public class Engine
    {
        private readonly RestaurantController controller;

        public Engine()
        {
            this.controller = new RestaurantController();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] commandItems = line.Split();
                string result = string.Empty;

                try
                {
                    switch (commandItems[0])
                    {
                        case "AddFood":
                            result += this.controller.AddFood(commandItems[1],
                                commandItems[2],
                                decimal.Parse(commandItems[3]));
                            break;

                        case "AddDrink":
                            result += this.controller.AddDrink(commandItems[1],
                                commandItems[2],
                                int.Parse(commandItems[3]),
                                commandItems[4]);
                            break;

                        case "AddTable":
                            result += this.controller.AddTable(commandItems[1],
                                int.Parse(commandItems[2]),
                                int.Parse(commandItems[3]));
                            break;

                        case "ReserveTable":
                            result += this.controller.ReserveTable(
                                int.Parse(commandItems[1]));
                            break;

                        case "OrderFood":
                            result += this.controller.OrderFood(int.Parse(commandItems[1]),
                                commandItems[2]);
                            break;

                        case "OrderDrink":
                            result += this.controller.OrderDrink(int.Parse(commandItems[1]),
                                commandItems[2],
                                commandItems[3]);
                            break;

                        case "LeaveTable":
                            result += this.controller.LeaveTable(
                                int.Parse(commandItems[1]));
                            break;

                        case "GetFreeTablesInfo":
                            result += this.controller.GetFreeTablesInfo();
                            break;

                        case "GetOccupiedTablesInfo":
                            result += this.controller.GetOccupiedTablesInfo();
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

            Console.WriteLine(this.controller.GetSummary());
        }
    }
}