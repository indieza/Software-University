namespace MortalEngines.IO.Contracts
{
    using MortalEngines.Core.Contracts;
    using System.Collections.Generic;

    public interface IReader
    {
        IList<ICommand> ReadCommands();
    }
}