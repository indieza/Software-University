namespace _10.TheHeiganDance
{
    using System;
    using System.Linq;

    internal class TheHeiganDance
    {
        private const double PlagueCloudDamage = 3500;
        private const double EruptionDamage = 6000;
        private const double PlayerStartingHitPoints = 18500;
        private const double HeiganStartingHitPoints = 3000000;
        private const int ChamberSize = 15;
        private const int ChamberMaxLimit = 14;
        private const int ChamberMinLimit = 0;

        private static void Main()
        {
            double damageToHeigan = double.Parse(Console.ReadLine());

            var playersPositon = new[] { ChamberSize / 2, ChamberSize / 2 };

            var playersPoints = PlayerStartingHitPoints;
            var heiganPoints = HeiganStartingHitPoints;
            bool isHeigeanDefeated, isPlayerDead = false;

            bool hasCloud = false;
            var causeOfDeath = string.Empty;

            while (true)
            {
                var spellTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var spell = spellTokens[0];
                var spellRow = int.Parse(spellTokens[1]);
                var spellCol = int.Parse(spellTokens[2]);

                heiganPoints -= damageToHeigan;
                isHeigeanDefeated = heiganPoints <= 0;

                if (hasCloud)
                {
                    playersPoints -= PlagueCloudDamage;
                    hasCloud = false;
                    isPlayerDead = playersPoints <= 0;
                }

                if (isHeigeanDefeated || isPlayerDead)
                {
                    break;
                }

                if (IsPlayerInDamagedZone(spellRow, spellCol, playersPositon))
                {
                    if (!PlayerTryToEscape(spellRow, spellCol, ref playersPositon))
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playersPoints -= PlagueCloudDamage;
                                hasCloud = true;
                                causeOfDeath = "Plague Cloud";
                                break;

                            case "Eruption":
                                playersPoints -= EruptionDamage;
                                causeOfDeath = spell;
                                break;
                        }
                    }
                }

                isPlayerDead = playersPoints <= 0;

                if (isPlayerDead)
                {
                    break;
                }
            }

            Console.WriteLine(isHeigeanDefeated ? "Heigan: Defeated!" : $"Heigan: {heiganPoints:f2}");

            Console.WriteLine(isPlayerDead ? $"Player: Killed by {causeOfDeath}" : $"Player: {playersPoints}");

            Console.WriteLine($"Final position: {playersPositon[0]}, {playersPositon[1]}");
        }

        private static bool IsPlayerInDamagedZone(int spellRow, int spellCol, int[] playersPositon)
        {
            bool isHitRow = playersPositon[0] >= spellRow - 1 && playersPositon[0] <= spellRow + 1;
            bool isHitCol = playersPositon[1] >= spellCol - 1 && playersPositon[1] <= spellCol + 1;
            return isHitCol && isHitRow;
        }

        private static bool PlayerTryToEscape(int spellRow, int spellCol, ref int[] playersPositon)
        {
            var curRow = playersPositon[0];
            var curCol = playersPositon[1];

            if (curRow - 1 >= ChamberMinLimit && curRow - 1 < spellRow - 1)
            {
                playersPositon = new[] { curRow - 1, curCol };
                return true;
            }

            if (curCol + 1 <= ChamberMaxLimit && curCol + 1 > spellCol + 1)
            {
                playersPositon = new[] { curRow, curCol + 1 };
                return true;
            }

            if (curRow + 1 <= ChamberMaxLimit && curRow + 1 > spellRow + 1)
            {
                playersPositon = new[] { curRow + 1, curCol };
                return true;
            }

            if (curCol - 1 >= ChamberMinLimit && curCol - 1 < spellCol - 1)
            {
                playersPositon = new[] { curRow, curCol - 1 };
                return true;
            }

            return false;
        }
    }
}