namespace MilitaryElite
{
    public class MissionFactory
    {
        public Mission CreateMission(string codeName, string state)
        {
            Mission mission = new Mission(codeName, state);
            return mission;
        }
    }
}