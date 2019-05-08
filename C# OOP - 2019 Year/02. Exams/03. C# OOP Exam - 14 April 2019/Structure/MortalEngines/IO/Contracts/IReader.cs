using System.Collections.Generic;
using System.Windows.Input;

namespace MortalEngines.IO.Contracts
{
    public interface IReader
    {
        IList<ICommand> ReadCommands();
    }
}