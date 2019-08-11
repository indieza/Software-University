namespace ViceCity.Models.Players.Models
{
    public class CivilPlayer : Player
    {
        private const int InitialLifePoints = 50;

        public CivilPlayer(string name)
            : base(name, InitialLifePoints)
        {
        }
    }
}