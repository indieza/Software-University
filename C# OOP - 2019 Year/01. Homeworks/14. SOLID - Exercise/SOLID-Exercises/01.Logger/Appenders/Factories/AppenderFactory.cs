namespace _01.Logger.Appenders.Factories
{
    using System;
    using Contracts;
    using _01.Logger.Layouts.Contracts;
    using Loggers;
    public class AppenderFactory:IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            switch (type.ToLower())
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout,new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
