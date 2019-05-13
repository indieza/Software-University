using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.Players;
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
            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += 40;
                attackPlayer.CardRepository.Cards.ToList().ForEach(c => c.DamagePoints += 30);
            }
            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += 40;
                enemyPlayer.CardRepository.Cards.ToList().ForEach(c => c.DamagePoints += 30);
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            while (true)
            {
                int attackerAttackPoint = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                enemyPlayer.TakeDamage(attackerAttackPoint);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                int enemyAttackPoint = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                attackPlayer.TakeDamage(enemyAttackPoint);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }
    }
}