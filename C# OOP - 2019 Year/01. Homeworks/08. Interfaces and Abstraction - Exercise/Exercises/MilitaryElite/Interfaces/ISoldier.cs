namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISoldier
    {
        int Id { get; }

        string FirstName { get; }

        string LastName { get; }
    }
}