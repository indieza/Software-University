namespace PlayersAndMonsters.Common
{
    public class ExceptionMessages
    {
        public const string NullPlayerUsername = "Player's username cannot be null or an empty string.";

        public const string NegativePlayeHealth = "Player's health bonus cannot be less than zero.";

        public const string NegativeDamagePoints = "Damage points cannot be less than zero.";

        public const string NullCardName = "Card's name cannot be null or an empty string.";

        public const string NegativeCardDamagePoints = "Card's damage points cannot be less than zero.";

        public const string NegativeCardHealthPoints = "Card's HP cannot be less than zero.";

        public const string DeathPlayer = "Player is dead!";

        public const string NullPlayer = "Player cannot be null";

        public const string PlayerExist = "Player {0} already exists!";

        public const string NullCard = "Card cannot be null!";

        public const string CardExist = "Card {0} already exists!";
    }
}