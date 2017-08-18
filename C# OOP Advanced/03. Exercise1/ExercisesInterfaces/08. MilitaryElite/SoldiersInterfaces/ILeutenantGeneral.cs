using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILeutenantGeneral : IPrivate
    {
        IList<ISoldier> Soldiers { get; }
    }
}