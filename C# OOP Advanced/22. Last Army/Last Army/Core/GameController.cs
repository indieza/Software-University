using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private MissionController missionControllerField;
    private SoldierFactory soldierFactory;
    private MissionFactory missionFactory;
    private IArmy army;
    private IWareHouse wareHouse;

    public GameController()
    {
        this.Army = new Army();
        this.WearHouse = new WareHouse();
        this.MissionControllerField = new MissionController(this.army, this.wareHouse);
    }

    public IArmy Army
    {
        get { return army; }
        set { this.army = value; }
    }

    public IWareHouse WearHouse
    {
        get { return this.wareHouse; }
        set { this.wareHouse = value; }
    }

    public MissionController MissionControllerField
    {
        get { return this.missionControllerField; }
        set { this.missionControllerField = value; }
    }

    public SoldierFactory SoldierFactory
    {
        get { return this.soldierFactory; }
        set { this.soldierFactory = value; }
    }

    public MissionFactory MissionFactory
    {
        get { return this.missionFactory; }
        set { this.missionFactory = value; }
    }

    public void ProcessCommand(string input)
    {
        List<string> items = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        string commandType = items[0];
        string commandPattern = OutputMessages.Process + commandType + OutputMessages.Command;
        List<string> data = items.Skip(0).ToList();

        try
        {
            this.GetType().GetMethod(commandPattern, BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, new object[] { data });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ProcessSoldierCommand(List<string> items)
    {
        if (items[0].Equals("Regenerate"))
        {
            this.army.RegenerateTeam(items[1]);
        }
        this.AddSoldierToArmy(items);
    }

    private void AddSoldierToArmy(List<string> items)
    {
        string type = items[0];
        string name = items[1];
        int age = int.Parse(items[2]);
        double experience = double.Parse(items[3]);
        double endurance = double.Parse(items[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);
    }

    public void ProduceSummury()
    {
    }
}