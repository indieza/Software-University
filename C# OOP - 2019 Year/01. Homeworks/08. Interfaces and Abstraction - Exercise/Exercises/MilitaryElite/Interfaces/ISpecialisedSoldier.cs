namespace MilitaryElite
{
    using System.Collections.Generic;

    public interface ISpecialisedSoldier : IPrivate, ICorp
    {
        IList<ICorp> Corps { get; }
    }
}