
namespace PlayersAndMonsters.Models.Cards.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class TrapCard : Card
    {
        private const int InitialDamagePoints = 120;
        private const int InitialHealthPoints = 5;
        public TrapCard(string name) 
            : base(name, InitialDamagePoints, InitialHealthPoints)
        {
        }
    }
}