namespace _01.Logger.Appenders.Contracts
{
    using _01.Logger.Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type,ILayout layout);
    }
}
