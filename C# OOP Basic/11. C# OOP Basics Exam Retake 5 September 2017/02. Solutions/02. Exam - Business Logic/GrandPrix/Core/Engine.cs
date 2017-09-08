using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;
    private ConsoleReader reader;
    private ConsoleWriter writer;

    public Engine()
    {
        this.raceTower = new RaceTower();
        this.reader = new ConsoleReader();
        this.writer = new ConsoleWriter();
    }

    public void Run()
    {
        try
        {
            int lapsNumber = int.Parse(this.reader.ReadLine());
            int trackLength = int.Parse(this.reader.ReadLine());

            this.raceTower.SetTrackInfo(lapsNumber, trackLength);

            while (this.raceTower.CurrentLap < lapsNumber)
            {
                List<string> items = this.reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string key = items[0];
                items.RemoveAt(0);

                switch (key)
                {
                    case "RegisterDriver":
                        this.raceTower.RegisterDriver(items);
                        break;

                    case "Leaderboard":
                        this.writer.WriteLine(this.raceTower.GetLeaderboard());
                        break;

                    case "CompleteLaps":
                        try
                        {
                            string result = this.raceTower.CompleteLaps(items);

                            if (result != string.Empty)
                            {
                                this.writer.WriteLine(result);
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;

                    case "Box":
                        this.raceTower.DriverBoxes(items);
                        break;

                    case "ChangeWeather":
                        this.raceTower.ChangeWeather(items);
                        break;
                }
            }

            this.writer.WriteLine($"{this.raceTower.Winner.Name} wins the race for {this.raceTower.Winner.TotalTime:F3} seconds.");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}