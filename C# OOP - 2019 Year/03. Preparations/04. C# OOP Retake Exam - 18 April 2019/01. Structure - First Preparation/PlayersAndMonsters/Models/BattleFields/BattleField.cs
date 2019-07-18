
namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Models;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System.Linq;

    public class BattleField : IBattleField
    {
        private const int InitialHealthIncreasment = 40;
        private const int InithialDamageIncreasment = 30;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            IsPlayerDeath(attackPlayer, enemyPlayer);
            IncreaseCardDamageAndHealthOfThePlayer(attackPlayer, enemyPlayer);
            IncreasePlayerHealthPointsWithCards(attackPlayer, enemyPlayer);

            while (true)
            {
                int attackerDamagePoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                int enemyDamagePoints = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private static void IncreasePlayerHealthPointsWithCards(IPlayer attackPlayer, IPlayer enemyPlayer)
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

        private static void IncreaseCardDamageAndHealthOfThePlayer(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                attackPlayer.Health += InitialHealthIncreasment;

                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += InithialDamageIncreasment;
                }
            }
            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += InitialHealthIncreasment;

                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += InithialDamageIncreasment;
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