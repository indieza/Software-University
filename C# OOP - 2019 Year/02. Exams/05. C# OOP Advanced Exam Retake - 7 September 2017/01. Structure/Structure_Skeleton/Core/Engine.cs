using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager manager;

    public Engine()
    {
        this.manager = new DraftManager();
    }

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var data = input.Split().ToList();
            var command = data[0];
            switch (command)
            {
                case "RegisterHarvester":
                    var args = new List<string>(data.Skip(1).ToList());
                    manager.RegisterHarvester(args);
                    break;
                case "RegisterProvider":
                    args = new List<string>(data.Skip(1).ToList());
                    manager.RegisterProvider(args);
                    break;
                case "Day":
                    manager.Day();
                    break;
                case "Mode":
                    args = new List<string>(data.Skip(1).ToList());
                    manager.Mode(args);
                    break;
                case "Check":
                    args = new List<string>(data.Skip(1).ToList());
                    //Console.WriteLine(manager.Check(args));
                    break;
                default:
                    manager.ShutDown();
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
