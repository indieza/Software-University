namespace PlayersAndMonsters.Models.BattleFields
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
        private const int IncreaseHealthPoints = 40;
        private const int IncreaseDamagePointOfTheCard = 30;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            CheckPlayerIsEmpty(attackPlayer, enemyPlayer);
            IncreasePlayerHealthAndDamagePoints(attackPlayer, enemyPlayer);
            TakeBonusHealth(attackPlayer, enemyPlayer);

            while (true)
            {
                int attackerDamagePoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.Health <= 0)
                {
                    break;
                }

                int enemyDamagePoints = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.Health <= 0)
                {
                    break;
                }
            }
        }

        private static void CheckPlayerIsEmpty(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException(ExceptionMessages.DeathPlayer);
            }
        }

        private static void TakeBonusHealth(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            foreach (ICard card in attackPlayer.CardRepository.Cards)
            {
                attackPlayer.Health += card.HealthPoints;
            }
            foreach (ICard card in enemyPlayer.CardRepository.Cards)
            {
                enemyPlayer.Health += card.HealthPoints;
            }
        }

        private static void IncreasePlayerHealthAndDamagePoints(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                attackPlayer.Health += IncreaseHealthPoints;

                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += IncreaseDamagePointOfTheCard;
                }
            }
            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += IncreaseHealthPoints;

                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += IncreaseDamagePointOfTheCard;
                }
            }
        }
    }
}