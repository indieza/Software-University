namespace _01.Logger.Appenders
{
    using Loggers.Enums;
    using _01.Logger.Layouts.Contracts;
    using System;

    public class ConsoleAppender:Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel<=reportLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                   $"Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }
    }
}
