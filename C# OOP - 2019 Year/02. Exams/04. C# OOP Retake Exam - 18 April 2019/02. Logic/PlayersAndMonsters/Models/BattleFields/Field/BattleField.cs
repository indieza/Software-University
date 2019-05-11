using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields.Field
{
    public class BattleField : IBattleField
    {
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

            int attackerBonusHealth = attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            attackPlayer.Health += attackerBonusHealth;

            int enemyBonusHealth = enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyBonusHealth;

            while (attackPlayer.CardRepository.Cards.Count != 0
                && enemyPlayer.CardRepository.Cards.Count != 0)
            {
                ICard attackerCard = attackPlayer.CardRepository.Cards.ToList()[0];
                ICard enemyCard = enemyPlayer.CardRepository.Cards.ToList()[0];

                enemyPlayer.TakeDamage(attackerCard.DamagePoints);

                if (enemyPlayer.IsDead)
                {
                    attackPlayer.CardRepository.Remove(attackerCard);
                    break;
                }

                attackPlayer.TakeDamage(enemyCard.DamagePoints);

                if (attackPlayer.IsDead)
                {
                    enemyPlayer.CardRepository.Remove(enemyCard);
                    break;
                }

                attackPlayer.CardRepository.Cards.ToList().RemoveAt(0);
                enemyPlayer.CardRepository.Cards.ToList().RemoveAt(0);
            }
        }
    }
}