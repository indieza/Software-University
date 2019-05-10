using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields.Field
{
    public class BattleField : IBattleField
    {
        // TODO:::

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
        }
    }
}