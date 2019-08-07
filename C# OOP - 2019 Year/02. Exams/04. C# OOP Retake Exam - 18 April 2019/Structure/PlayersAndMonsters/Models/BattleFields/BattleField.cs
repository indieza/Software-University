namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            IsPlayerDeath(attackPlayer, enemyPlayer);

            IncreasePoints(attackPlayer, enemyPlayer);

            TakeBonus(attackPlayer, enemyPlayer);

            while (true)
            {
                int damageAttacker = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                enemyPlayer.TakeDamage(damageAttacker);

                if (enemyPlayer.IsDead == true)
                {
                    break;
                }

                int damageEnemy = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                attackPlayer.TakeDamage(damageEnemy);

                if (attackPlayer.IsDead == true)
                {
                    break;
                }
            }
        }

        private static void TakeBonus(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            int bonushealthAttacker = attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            int bonushealthEnemy = enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            attackPlayer.Health += bonushealthAttacker;
            enemyPlayer.Health += bonushealthEnemy;
        }

        private static void IncreasePoints(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private static void IsPlayerDeath(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException(ExceptionMessages.DeathPlayer);
            }
        }
    }
}