namespace PlayersAndMonsters.Models.BattleFields.Models
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        private const int IncreasePlayerHealth = 40;
        private const int IncreaseCardDamagePoints = 30;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            CheckIsPlayerDeath(attackPlayer, enemyPlayer);
            IncreasePlayerPoints(attackPlayer, enemyPlayer);
            IncreasePlayerHealthPoints(attackPlayer, enemyPlayer);

            while (true)
            {
                int attackerDamagePoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.IsDead == true)
                {
                    break;
                }

                int enemyDamagePoints = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.IsDead == true)
                {
                    break;
                }
            }
        }

        private static void IncreasePlayerHealthPoints(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
        }

        private static void IncreasePlayerPoints(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                attackPlayer.Health += IncreasePlayerHealth;

                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += IncreaseCardDamagePoints;
                }
            }

            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += IncreasePlayerHealth;

                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += IncreaseCardDamagePoints;
                }
            }
        }

        private static void CheckIsPlayerDeath(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead == true)
            {
                throw new ArgumentException(ExceptionMessages.DeathPlayer);
            }
            if (enemyPlayer.IsDead == true)
            {
                throw new ArgumentException(ExceptionMessages.DeathPlayer);
            }
        }
    }
}