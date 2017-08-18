namespace _04.TheCommandsStrikeBack.Contracts
{
    public interface IRepository
    {
        string Statistics { get; }

        void RemoveUnit(string unitType);

        void AddUnit(IUnit unit);
    }
}