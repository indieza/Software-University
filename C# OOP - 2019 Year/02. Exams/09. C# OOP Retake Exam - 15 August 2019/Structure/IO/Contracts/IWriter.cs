namespace SpaceStation.IO.Contracts
{
    interface IWriter
    {
        void WriteLine(string message);

        void Write(string message);
    }
}
