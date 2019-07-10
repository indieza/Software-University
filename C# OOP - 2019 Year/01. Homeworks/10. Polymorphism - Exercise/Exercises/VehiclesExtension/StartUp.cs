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
            double carTankCapacity = double.Parse(carItems[3]);

            Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckItems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckItems[1]);
            double truckFuelConsumption = double.Parse(truckItems[2]);
            double truckTankCapacity = double.Parse(truckItems[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busItems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double busFuelQuantity = double.Parse(busItems[1]);
            double busFuelConsumption = double.Parse(busItems[2]);
            double busTankCapacity = double.Parse(busItems[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
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
                        else if (type == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (type == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double fuel = double.Parse(commandItems[2]);

                        if (type == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(fuel);
                        }
                        else if (type == "Bus")
                        {
                            bus.Refuel(fuel);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        double distance = double.Parse(commandItems[2]);
                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}