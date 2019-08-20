namespace SpaceStation.IO.Contracts
{
    internal interface IWriter
    {
        void WriteLine(string message);

        void Write(string message);
    }
}