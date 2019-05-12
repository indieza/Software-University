using System.Collections.Generic;

public interface ICommand
{
    IList<string> Arguments { get; }

    string Execute();
}