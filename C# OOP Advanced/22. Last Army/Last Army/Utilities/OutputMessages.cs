public class OutputMessages
{
    public const double MaxEnduranceLevel = 100;

    #region OutputMessages

    public const string MissionSuccessful = "Mission completed - {0}";
    public const string MissionDeclined = "Mission declined - {0}";
    public const string MissionOnHold = "Mission on hold - {0}";
    public const string SoldierToString = "{0} - {1}";

    #endregion OutputMessages

    #region Weapons

    public const double RpgWeight = 17.1;
    public const double NightVisionWeight = 0.8;
    public const double MachineGunWeight = 10.6;
    public const double KnifeWeight = 0.4;
    public const double HelmetWeight = 2.3;
    public const double GunWeight = 1.4;
    public const double GrenadesWeight = 1.0;
    public const double AutomaticMachineWeight = 6.3;

    #endregion Weapons

    #region HardMission

    public const string HardMissionName = "Disposal of terrorists";
    public const double HardEnduranceRequired = 80;
    public const double HardWearLevelDecrease = 70;

    #endregion HardMission

    #region MediumMission

    public const double MediumEnduranceRequired = 50;
    public const string MediumMissionName = "Capturing dangerous criminals";
    public const double MediumWearLevelDecrease = 50;

    #endregion MediumMission

    #region EasyMission

    public const double EasyEnduranceRequired = 20;
    public const string EasyMissionName = "Suppression of civil rebellion";
    public const double EasyWearLevelDecrease = 30;

    #endregion EasyMission

    #region Soldier

    public const double RankerMultiply = 1.5;
    public const double CorporalMultiply = 2.5;
    public const double SpecialForceMultiply = 3.5;
    public const double RegenerateRanker = 10;
    public const double RegenerateCorporal = 10;
    public const double RegenerateSpecialForce = 30;

    #endregion Soldier

    #region ProcessCommand

    public const string Process = "Process";
    public const string Command = "Command";

    #endregion ProcessCommand
}