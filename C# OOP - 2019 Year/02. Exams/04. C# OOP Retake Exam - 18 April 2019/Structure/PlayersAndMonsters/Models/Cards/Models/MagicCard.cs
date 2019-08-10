namespace PlayersAndMonsters.Models.Cards.Models
{
    public class MagicCard : Card
    {
        private const int InitialDamagePoints = 5;
        private const int InitialHealthPoints = 80;

        public MagicCard(string name)
            : base(name, InitialDamagePoints, InitialHealthPoints)
        {
        }
    }
}