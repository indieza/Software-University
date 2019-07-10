using System;

namespace Vehicles
{
    public class StartUp
    {
        private static void Main()
        {
            string[] carItems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carItems[1]);
            double carFuelConsumption = double.Parse(carItems[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckItems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckItems[1]);
            double truckFuelConsumption = double.Parse(truckItems[2]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] commandItems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = commandItems[0];
                string type = commandItems[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(commandItems[2]);

                    if (type == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(commandItems[2]);

                    if (type == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}