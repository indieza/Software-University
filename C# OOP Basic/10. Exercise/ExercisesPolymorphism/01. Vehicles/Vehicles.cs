using System;

namespace _01.Vehicles
{
    internal class Vehicles
    {
        private static void Main()
        {
            string[] carItems = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carItems[1]);
            double carLitersPerKilometer = double.Parse(carItems[2]);

            string[] truckItems = Console.ReadLine().Split();

            double truckFuelQuantity = double.Parse(truckItems[1]);
            double truckLitersPerKilometer = double.Parse(truckItems[2]);

            Car car = new Car(carFuelQuantity, carLitersPerKilometer);
            Truck truck = new Truck(truckFuelQuantity, truckLitersPerKilometer);

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
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}