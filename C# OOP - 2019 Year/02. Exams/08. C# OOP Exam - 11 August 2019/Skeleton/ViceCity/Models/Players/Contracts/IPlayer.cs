using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        bool IsAlive { get; }

        IRepository<IGun> GunRepository { get; }

        int LifePoints { get; }

        void TakeLifePoints(int points);
    }
}