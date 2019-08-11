namespace ViceCity.IO.Contracts
{
    internal interface IWriter
    {
        void WriteLine(string line);

        void Write(string line);
    }
}