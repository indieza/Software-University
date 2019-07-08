namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}