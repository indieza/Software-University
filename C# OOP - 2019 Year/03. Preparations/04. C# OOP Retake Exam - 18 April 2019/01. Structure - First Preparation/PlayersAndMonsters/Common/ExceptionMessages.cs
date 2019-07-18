
namespace PlayersAndMonsters.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class ExceptionMessages
    {
        public const string EmptyUsername = "Player's username cannot be null or an empty string.";

        public const string NegativePlayerHealthPoints = "Player's health bonus cannot be less than zero.";

        public const string NegativeDamagePoints = "Damage points cannot be less than zero.";

        public const string EmptyCardName = "Card's name cannot be null or an empty string.";

        public const string NegativeCardHealthPoints = "Card's HP cannot be less than zero.";

        public const string DeathPlayer = "Player is dead!";

        public const string NullPlayer = "Player cannot be null";

        public const string PlayerAlreadyExist = "Player {0} already exists!";

        public const string NullCard = "Card cannot be null!";

        public const string CardAlreadyExist = "Card {0} already exists!";
    }
}