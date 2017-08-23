using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string Process = "Parse";
    private const string Command = "Command";
    private const string Regenerate = "Regenerate";
    private const string Results = "Results:";
    private const string Soldiers = "Soldiers:";
    private readonly MissionController missionController;
    private readonly IArmy army;
    private readonly ISoldierFactory soldierFactory;
    private readonly IMissionFactory missionFactory;
    private readonly IWareHouse wareHouse;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.Writer = writer;
        this.missionFactory = new MissionFactory();
        this.soldierFactory = new SoldierFactory();
        this.missionController = new MissionController(this.army, this.wareHouse);
    }

    public IWriter Writer
    {
        get { return this.writer; }
        set { this.writer = value; }
    }

    public void ProcessCommand(string input)
    {
        List<string> data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        string commandExecute = data[0];
        data.RemoveAt(0);
        string pattern = Process + commandExecute + Command;
        try
        {
            this.GetType()
                .GetMethod(pattern, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                .Invoke(this, new object[] { data });
        }
        catch (Exception exception)
        {
            this.Writer.StoreMessage(exception.InnerException.Message);
        }
    }

    private void ParseWareHouseCommand(List<string> data)
    {
        string name = data[0];
        int quantity = int.Parse(data[1]);
        this.wareHouse.AddAmmunitions(name, quantity);
    }

    private void ParseSoldierCommand(List<string> data)
    {
        if (data[0] == Regenerate)
        {
            this.army.RegenerateTeam(data[1]);
        }
        else
        {
            this.AddSoldier(data);
        }
    }

    private void ParseMissionCommand(List<string> data)
    {
        string type = data[0];
        double scoreToComplete = double.Parse(data[1]);
        IMission mission = this.missionFactory.CreateMission(type, scoreToComplete);
        this.Writer.StoreMessage(this.missionController.PerformMission(mission));
    }

    private void AddSoldier(List<string> data)
    {
        string type = data[0];
        string name = data[1];
        int age = int.Parse(data[2]);
        double experience = double.Parse(data[3]);
        double endurance = double.Parse(data[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldier, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    public void ProduceSummary()
    {
        List<ISoldier> soldiers = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        this.missionController.FailMissionsOnHold();

        this.Writer.StoreMessage(Results);
        this.Writer.StoreMessage(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));
        this.Writer.StoreMessage(string.Format(OutputMessages.MissionsSummuryFailed, this.missionController.FailedMissionCounter));

        this.Writer.StoreMessage(Soldiers);

        foreach (var soldier in soldiers)
        {
            this.Writer.StoreMessage(soldier.ToString());
        }
    }
}