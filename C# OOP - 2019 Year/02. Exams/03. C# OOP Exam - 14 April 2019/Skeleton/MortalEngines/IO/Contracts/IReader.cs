namespace MortalEngines.IO.Contracts
{
    using System.Collections.Generic;
    using System.Windows.Input;

    public interface IReader
    {
        IList<ICommand> ReadCommands();
    }
}