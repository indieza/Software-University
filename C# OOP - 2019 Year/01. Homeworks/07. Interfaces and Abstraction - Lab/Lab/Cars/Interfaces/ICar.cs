namespace Cars.Interfaces
{
    public interface ICar
    {
        string Model { get; }

        string Color { get; }

        string Start();

        string Stop();
    }
}