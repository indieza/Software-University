namespace Service.Models.Contracts
{
    public interface IPart
    {
        string Name { get; }

        decimal Cost { get; }

        bool IsBroken { get; }

        void Repair();

        string Report();
    }
}
