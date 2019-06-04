using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class StartUp
    {
        private const double distance = 20.0;

        private static void Main()
        {
            List<Tire[]> allTires = new List<Tire[]>();
            List<Engine> allEngines = new List<Engine>();
            List<Car> allCars = new List<Car>();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                string[] tires = input.Split(' ');

                Tire[] fourTires = new Tire[4]
                {
                        new Tire(int.Parse(tires[0]),double.Parse(tires[1])),
                        new Tire(int.Parse(tires[2]),double.Parse(tires[3])),
                        new Tire(int.Parse(tires[4]),double.Parse(tires[5])),
                        new Tire(int.Parse(tires[6]),double.Parse(tires[7])),
                };

                allTires.Add(fourTires);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] engines = input.Split(' ');

                for (int i = 0; i < engines.Length - 1; i++)
                {
                    int engineHorsePower = int.Parse(engines[i]);
                    double engineCubicCapacity = double.Parse(engines[i + 1]);
                    Engine engine = new Engine(engineHorsePower, engineCubicCapacity);

                    allEngines.Add(engine);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] carInfo = input.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tireIndex = int.Parse(carInfo[6]);

                Car car = new Car(
                    make, model, year, fuelQuantity, fuelConsumption, allEngines[engineIndex], allTires[tireIndex]);

                var isSpecialCar = IsSpecialCar(car);

                if (isSpecialCar)
                {
                    car.Drive(distance);
                }

                if (car.FuelQuantity != fuelQuantity)
                {
                    allCars.Add(car);
                }

                input = Console.ReadLine();
            }

            foreach (var specialCar in allCars)
            {
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }

        private static bool IsSpecialCar(Car car)
        {
            return car.Year >= 2017 && car.Engine.HorsePower >= 330 && car.Tires.Select(x => x.Pressure)
                .Sum() >= 9 && car.Tires.Select(x => x.Pressure).Sum() <= 10;
        }
    }

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,
            Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }

        public Tire[] Tires
        {
            get
            {
                return this.tires;
            }
            set
            {
                this.tires = value;
            }
        }

        public void Drive(double distance)
        {
            if (distance * this.FuelConsumption / 100 > this.FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                this.FuelQuantity -= this.FuelConsumption / 100 * distance;
            }
        }

        public string WhoAmI()
        {
            StringBuilder carInfo = new StringBuilder();

            carInfo.AppendLine($"Make: {this.Make}");
            carInfo.AppendLine($"Model: {this.Model}");
            carInfo.AppendLine($"Year: {this.Year}");
            carInfo.Append($"Fuel: {this.FuelQuantity:F2}L");

            return carInfo.ToString();
        }
    }

    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                this.horsePower = value;
            }
        }

        public double CubicCapacity
        {
            get
            {
                return this.cubicCapacity;
            }
            set
            {
                this.cubicCapacity = value;
            }
        }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }

        public double Pressure
        {
            get
            {
                return this.pressure;
            }
            set
            {
                this.pressure = value;
            }
        }
    }
}