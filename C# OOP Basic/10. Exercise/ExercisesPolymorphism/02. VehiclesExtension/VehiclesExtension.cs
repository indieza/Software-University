using System;

namespace _02.VehiclesExtension
{
    internal class VehiclesExtension
    {
        private static void Main()
        {
            string[] carItems = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carItems[1]);
            double carLitersPerKilometer = double.Parse(carItems[2]);
            double carTankCapacity = double.Parse(carItems[3]);

            Car car = new Car(carFuelQuantity, carLitersPerKilometer, carTankCapacity);

            string[] truckItems = Console.ReadLine().Split();

            double truckFuelQuantity = double.Parse(truckItems[1]);
            double truckLitersPerKilometer = double.Parse(truckItems[2]);
            double truckTankCapacity = double.Parse(truckItems[3]);

            Truck truck = new Truck(truckFuelQuantity, truckLitersPerKilometer, truckTankCapacity);

            string[] busItems = Console.ReadLine().Split();

            double busFuelQuantity = double.Parse(busItems[1]);
            double busLitersPerKilometer = double.Parse(busItems[2]);
            double busTankCapacity = double.Parse(truckItems[3]);

            Bus bus = new Bus(busFuelQuantity, busLitersPerKilometer, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] lineItems = Console.ReadLine().Split();

                string command = lineItems[0];
                string vehicle = lineItems[1];

                if (command == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        car.FuelQuantity = car.DriveCar(double.Parse(lineItems[2]));
                    }
                    if (vehicle == "Truck")
                    {
                        truck.FuelQuantity = truck.DriveTruck(double.Parse(lineItems[2]));
                    }
                    if (vehicle == "Bus")
                    {
                        bus.FuelQuantity = bus.DriveBus(double.Parse(lineItems[2]));
                    }
                }
                if (command == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.FuelQuantity = car.RefuelCar(double.Parse(lineItems[2]));
                    }
                    if (vehicle == "Truck")
                    {
                        truck.FuelQuantity = truck.RefuelTruck(double.Parse(lineItems[2]));
                    }
                    if (vehicle == "Bus")
                    {
                        bus.FuelQuantity = bus.RefuelBus(double.Parse(lineItems[2]));
                    }
                }
                if (command == "DriveEmpty")
                {
                    bus.FuelQuantity = bus.DriveEmpty(double.Parse(lineItems[2]));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}