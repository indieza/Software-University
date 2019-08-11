namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Messages;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Guns.Models;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Models.Players.Models;
    using ViceCity.Repositories;

    public class Controller : IController
    {
        private const string MainPlayerNameKey = "Vercetti";
        private const string FullNameMainPlayer = "Tommy Vercetti";
        private const int InitialMainPlayerHealthPoints = 100;
        private readonly List<IPlayer> players;
        private readonly GunRepository gunRepository;
        private readonly GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.players = new List<IPlayer>();
            this.players.Add(new MainPlayer());
            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            if (type != nameof(Pistol) && type != nameof(Rifle))
            {
                return OutputMessages.InvalidGun;
            }

            IGun gun = null;

            switch (type)
            {
                case "Rifle":
                    gun = new Rifle(name);
                    break;

                case "Pistol":
                    gun = new Pistol(name);
                    break;

                default:
                    break;
            }

            this.gunRepository.Add(gun);
            return string.Format(OutputMessages.SuccessfullAddedGun, gun.Name, gun.GetType().Name);
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepository.Models.Count == 0)
            {
                return OutputMessages.NoAvailableWeapon;
            }

            if (name == MainPlayerNameKey)
            {
                IPlayer playerVercetti = this.players
                    .FirstOrDefault(
                    p => p.Name == FullNameMainPlayer && p.GetType().Name == nameof(MainPlayer));

                IGun gunVercetti = this.gunRepository.Models.FirstOrDefault(g => g.CanFire == true);
                this.gunRepository.Remove(gunVercetti);

                playerVercetti.GunRepository.Add(gunVercetti);
                return string.Format(OutputMessages.SuccessfullAddWeaponToMainPlayer, gunVercetti.Name);
            }

            if (this.players.FirstOrDefault(p => p.Name == name) == null)
            {
                return OutputMessages.PlayerNotExist;
            }

            IPlayer player = this.players.FirstOrDefault(p => p.Name == name);
            IGun gun = this.gunRepository.Models.FirstOrDefault(g => g.CanFire == true);

            this.gunRepository.Remove(gun);
            player.GunRepository.Add(gun);

            return string.Format(OutputMessages.SuccessfullAddWeaponToCivilPlayer, gun.Name, player.Name);
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.players.Add(player);
            return string.Format(OutputMessages.SuccessfullAddPlayer, player.Name);
        }

        public string Fight()
        {
            MainPlayer mainPlayer = (MainPlayer)this.players
                .FirstOrDefault(p => p.GetType().Name == nameof(MainPlayer));

            List<IPlayer> civilPlayers = this.players
                .Where(p => p.GetType().Name != nameof(MainPlayer))
                .ToList();

            this.gangNeighbourhood.Action(mainPlayer, civilPlayers);

            StringBuilder sb = new StringBuilder();

            if (civilPlayers.Any(p => p.IsAlive == true) &&
                mainPlayer.LifePoints == InitialMainPlayerHealthPoints)
            {
                sb.AppendLine(OutputMessages.EverythingIsOkay);
            }
            else
            {
                sb.AppendLine(OutputMessages.FightHappened);

                sb.AppendLine(string.Format(OutputMessages.TommyLifePoints, mainPlayer.LifePoints));

                sb.AppendLine(string.Format(OutputMessages.KilledPlayers,
                    civilPlayers.Where(p => p.IsAlive == false).Count()));
                sb.AppendLine(string.Format(OutputMessages.LeftPlayers,
                    civilPlayers.Where(p => p.IsAlive == true).Count()));
            }

            return sb.ToString().TrimEnd();
        }
    }
}