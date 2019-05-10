using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Cards
{
    public class MagicCard : Card
    {
        private const int damagePoints = 5;
        private const int healthPoints = 80;

        public MagicCard(string name)
            : base(name, damagePoints, healthPoints)
        {
        }
    }
}