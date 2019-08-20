namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;
    public interface IBag
    {
        ICollection<string> Items { get; }
    }
}
