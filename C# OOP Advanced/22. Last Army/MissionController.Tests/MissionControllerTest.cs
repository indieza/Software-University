using NUnit.Framework;

[TestFixture]
public class MissionControllerTest
{
    private MissionController missionController;

    [SetUp]
    public void TestInitialize()
    {
        this.missionController = new MissionController(new Army(), new WareHouse());
    }

    [Test]
    public void MissionsCountTest()
    {
        this.missionController.Missions.Enqueue(new Easy(12.5));
        this.missionController.Missions.Enqueue(new Hard(56));
        this.missionController.Missions.Enqueue(new Hard(5));

        Assert.AreEqual(3, this.missionController.Missions.Count);
    }

    [Test]
    public void FailedMissionCounterTest()
    {
        this.missionController.Missions.Enqueue(new Easy(12.5));
        this.missionController.Missions.Enqueue(new Hard(56));
        this.missionController.Missions.Enqueue(new Hard(5));
        this.missionController.Missions.Enqueue(new Hard(6));

        this.missionController.PerformMission(new Easy(23));

        Assert.AreEqual(1, this.missionController.FailedMissionCounter);
    }

    [Test]
    public void PerformMissionTest()
    {
        IArmy army = new Army();
        army.AddSoldier(new Corporal("Pepo", 12, 23, 2));
        army.AddSoldier(new Corporal("Ricky", 29, 29, 20));
        IWareHouse wareHouse = new WareHouse();
        wareHouse.AddAmmunitions("AutomaticMachine", 12);
        wareHouse.AddAmmunitions("Gun", 3);
        wareHouse.AddAmmunitions("Helmet", 5);
        wareHouse.AddAmmunitions("Knife", 12);
        wareHouse.AddAmmunitions("MachineGun", 3);
        wareHouse.AddAmmunitions("NightVision", 5);
        wareHouse.AddAmmunitions("RPG", 56);
        MissionController mc = new MissionController(army, wareHouse);

        mc.Missions.Enqueue(new Easy(12.5));
        mc.Missions.Enqueue(new Hard(56));
        mc.Missions.Enqueue(new Hard(5));
        mc.Missions.Enqueue(new Hard(6));

        string res = mc.PerformMission(new Easy(23));
        int n = res.Length;

        Assert.AreEqual(229, n);
    }
}