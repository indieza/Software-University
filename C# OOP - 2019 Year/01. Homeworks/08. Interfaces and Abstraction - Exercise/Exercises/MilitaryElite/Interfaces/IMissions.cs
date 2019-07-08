namespace MilitaryElite
{
    public interface IMissions
    {
        string CodeName { get; }

        void CompleteMission();
    }
}