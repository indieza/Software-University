namespace _01.Logger.Appenders
{
    using Contracts;
    using _01.Logger.Layouts.Contracts;
    using Loggers.Enums;

    public abstract class Appender:IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
        

        public ReportLevel ReportLevel { get; set; }
    }
} 
