namespace _01.Logger.Core
{
    using Appenders.Factories;
    using _01.Logger.Layouts.Contracts;
    using Layouts.Factories;
    using System;
    using Loggers.Enums;
    using _01.Logger.Appenders.Contracts;
    using System.Collections.Generic;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly List<IAppender> appenders;

        private readonly IAppenderFactory appenderFactory;

        private readonly ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            var appenderType = args[0];
            var layoutType = args[1];
            var reportLevel = args.Length == 3?  Enum.Parse<ReportLevel>(args[2]): ReportLevel.INFO;
            
            var layout = this.layoutFactory.CreateLayout(layoutType);

            var appender = this.appenderFactory.CreateAppender(appenderType, layout);

            appender.ReportLevel = reportLevel;

            appenders.Add(appender);

        }

        public void AddReport(string[] args)
        {
            var reportLevel = Enum.Parse<ReportLevel>(args[0]);
            var dateTime = args[1];
            var message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
