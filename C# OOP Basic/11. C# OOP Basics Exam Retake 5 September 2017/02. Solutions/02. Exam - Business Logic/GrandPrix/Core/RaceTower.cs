using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private readonly DriverFactory driverFactory;
    private readonly TyreFactory tyreFactory;
    private readonly Dictionary<string, Driver> drivers;
    private readonly Dictionary<string, string> dnf;
    private int laps;
    private string weather;

    public RaceTower()
    {
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.drivers = new Dictionary<string, Driver>();
        this.dnf = new Dictionary<string, string>();
        this.CurrentLap = 0;
        this.weather = "Sunny";
    }

    public int CurrentLap { get; set; }

    public int TotalTrackLength { get; set; }

    public Driver Winner { get; set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.laps = lapsNumber;
        this.TotalTrackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        string driverType = commandArgs[0] + "Driver";
        string name = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);
        string tyreType = commandArgs[4] + "Tyre";
        double tyreHardness = double.Parse(commandArgs[5]);

        Tyre tyre;

        if (tyreType.Equals(nameof(UltrasoftTyre)))
        {
            double grip = double.Parse(commandArgs[6]);
            tyre = this.tyreFactory.CreateUltrasoftTyre(tyreType, tyreHardness, grip);
        }
        else
        {
            tyre = this.tyreFactory.CreateHardTyre(tyreType, tyreHardness);
        }

        Driver driver = this.driverFactory.CreateDriver(driverType, name, new Car(hp, fuelAmount, tyre));
        this.drivers.Add(name, driver);
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string key = commandArgs[0];
        string name = commandArgs[1];

        if (key.Equals("Refuel"))
        {
            double fuel = double.Parse(commandArgs[2]);
            this.drivers[name].Car.Refuel(fuel);
        }
        else if (key.Equals("ChangeTyres"))
        {
            string tyreType = commandArgs[2] + "Tyre";
            Tyre tyre = null;
            double hardness = double.Parse(commandArgs[3]);

            if (tyreType.Equals(nameof(HardTyre)))
            {
                tyre = this.tyreFactory.CreateHardTyre(tyreType, hardness);
            }
            else if (tyreType.Equals(nameof(UltrasoftTyre)))
            {
                double grip = double.Parse(commandArgs[4]);
                tyre = this.tyreFactory.CreateUltrasoftTyre(tyreType, hardness, grip);
            }

            this.drivers[name].Car.ChangeTyre(tyre);
        }

        double aditionalTime = 20;

        this.drivers[name].IncreaseTotalTimeForBoxCommand(aditionalTime);
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();

        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps + this.CurrentLap > this.laps)
        {
            throw new ArgumentException($"There is no time! On lap {this.CurrentLap}.");
        }

        for (int i = 0; i < numberOfLaps; i++)
        {
            List<Driver> leftDrivers = this.drivers.Values.ToList();

            foreach (Driver driver in leftDrivers)
            {
                this.drivers[driver.Name].IncreaseTotalTime(this.TotalTrackLength);

                try
                {
                    this.drivers[driver.Name].ReduceFuelAmount(this.TotalTrackLength);
                    this.drivers[driver.Name].Car.Tyre.DegradateTyre();
                }
                catch (Exception exception)
                {
                    this.dnf.Add(driver.Name, exception.Message);
                    this.drivers.Remove(driver.Name);
                }
            }

            this.CurrentLap++;

            leftDrivers = leftDrivers.OrderByDescending(d => d.TotalTime).ToList();

            Driver previousDriver = leftDrivers[0];

            for (int j = 1; j < leftDrivers.Count; j++)
            {
                bool canCrash = false;

                double interval = 2;

                if (previousDriver.GetType().Name == nameof(AggressiveDriver) && previousDriver.Car.Tyre.GetType().Name == nameof(UltrasoftTyre))
                {
                    interval = 3;

                    if (this.weather == "Foggy")
                    {
                        canCrash = true;
                    }
                }
                else if (previousDriver.GetType().Name == nameof(EnduranceDriver) && previousDriver.Car.Tyre.GetType().Name == nameof(HardTyre))
                {
                    interval = 3;

                    if (this.weather == "Rainy")
                    {
                        canCrash = true;
                    }
                }

                Driver currentDriver = leftDrivers[j];

                if (previousDriver.TotalTime - currentDriver.TotalTime <= interval)
                {
                    if (canCrash)
                    {
                        this.dnf.Add(previousDriver.Name, "Crashed");
                        this.drivers.Remove(previousDriver.Name);
                        continue;
                    }

                    previousDriver.DecreaseTotalTimeOvertake(interval);
                    currentDriver.IncreaseTotalTimeOvertaken(interval);

                    sb.AppendLine($"{previousDriver.Name} has overtaken {currentDriver.Name} on lap {this.CurrentLap}.");
                }

                previousDriver = leftDrivers[j];
            }
        }

        if (this.CurrentLap == this.laps)
        {
            this.Winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
        }

        return sb.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {this.CurrentLap}/{this.laps}");

        int count = 1;

        foreach (Driver driver in this.drivers.Values.OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{count} {driver.Name} {driver.TotalTime:F3}");
            count++;
        }

        foreach (KeyValuePair<string, string> dnfDriver in this.dnf.Reverse())
        {
            sb.AppendLine($"{count} {dnfDriver.Key} {dnfDriver.Value}");
            count++;
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string newWeather = commandArgs[0];
        this.weather = newWeather;
    }
}