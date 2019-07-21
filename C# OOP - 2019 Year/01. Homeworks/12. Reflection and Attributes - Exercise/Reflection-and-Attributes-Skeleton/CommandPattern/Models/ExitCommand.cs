namespace CommandPattern
{
    using CommandPattern;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}