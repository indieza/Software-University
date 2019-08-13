namespace ViceCity.Models.Neghbourhoods
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                IGun gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                IPlayer target = civilPlayers.FirstOrDefault(t => t.IsAlive == true);

                if (target == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                target.TakeLifePoints(damagePoints);
            }

            while (true)
            {
                IPlayer player = civilPlayers.FirstOrDefault(t => t.IsAlive == true);

                if (player == null)
                {
                    break;
                }

                IGun gun = player.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                mainPlayer.TakeLifePoints(damagePoints);

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }
        }
    }
}