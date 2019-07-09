namespace MilitaryElite
{
    public class MissionFactory
    {
        public Mission MakeMission(string codeName, string state)
        {
            Mission mission = new Mission(codeName, state);

            return mission;
        }
    }
}