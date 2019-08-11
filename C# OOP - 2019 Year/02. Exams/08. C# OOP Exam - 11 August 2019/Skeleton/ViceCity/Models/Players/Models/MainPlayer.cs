namespace ViceCity.Models.Players.Models
{
    public class MainPlayer : Player
    {
        private const int InitialLifePoints = 100;
        private const string InitialName = "Tommy Vercetti";

        public MainPlayer()
            : base(InitialName, InitialLifePoints)
        {
        }
    }
}