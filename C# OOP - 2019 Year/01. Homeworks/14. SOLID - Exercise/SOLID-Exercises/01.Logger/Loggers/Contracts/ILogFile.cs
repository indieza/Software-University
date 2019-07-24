namespace _01.Logger.Loggers.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
