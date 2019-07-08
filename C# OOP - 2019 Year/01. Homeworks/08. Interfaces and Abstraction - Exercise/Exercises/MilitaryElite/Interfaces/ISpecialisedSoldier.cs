namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISpecialisedSoldier : IPrivate
    {
        string Corp { get; }
    }
}