namespace SpaceStation.Models.Planets
{
    using System.Collections.Generic;

    public interface IPlanet
    {
        ICollection<string> Items { get; }

        string Name { get; }

        void AddItems(string[] planetItems);

        void RemoveItem(string item);
    }
}