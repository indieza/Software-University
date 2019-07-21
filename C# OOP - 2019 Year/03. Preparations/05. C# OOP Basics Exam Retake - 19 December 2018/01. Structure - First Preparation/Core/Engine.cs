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
                string[] commandItems = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (commandItems[0])
                    {
                        case "AddFood":
                            Console.WriteLine(this.controller.AddFood(commandItems[1],
                                commandItems[2],
                                decimal.Parse(commandItems[3])));
                            break;

                        case "AddDrink":
                            Console.WriteLine(this.controller.AddDrink(commandItems[1],
                                commandItems[2],
                                int.Parse(commandItems[3]),
                                commandItems[4]));
                            break;

                        case "AddTable":
                            Console.WriteLine(this.controller.AddTable(commandItems[1],
                                int.Parse(commandItems[2]),
                                int.Parse(commandItems[3])));
                            break;

                        case "ReserveTable":
                            Console.WriteLine(this.controller.ReserveTable(int.Parse(commandItems[1])));
                            break;

                        case "OrderFood":
                            Console.WriteLine(this.controller.OrderFood(int.Parse(commandItems[1]),
                                commandItems[2]));
                            break;

                        case "OrderDrink":
                            Console.WriteLine(this.controller.OrderDrink(int.Parse(commandItems[1]),
                                commandItems[2],
                                commandItems[3]));
                            break;

                        case "LeaveTable":
                            Console.WriteLine(this.controller.LeaveTable(int.Parse(commandItems[1])));
                            break;

                        case "GetFreeTablesInfo":
                            Console.WriteLine(this.controller.GetFreeTablesInfo());
                            break;

                        case "GetOccupiedTablesInfo":
                            Console.WriteLine(this.controller.GetOccupiedTablesInfo());
                            break;

                        default:
                            break;
                    }
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