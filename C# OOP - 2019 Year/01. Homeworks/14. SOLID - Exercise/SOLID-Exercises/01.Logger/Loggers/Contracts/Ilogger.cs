namespace _01.Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Info(string dateTime, string infoMessage);

        void Warning(string dateTime, string errorMessage);

        void Error(string dateTime, string infoMessage);

        void Critical(string dateTime, string infoMessage);

        void Fatal(string dateTime, string infoMessage);
    }
}
