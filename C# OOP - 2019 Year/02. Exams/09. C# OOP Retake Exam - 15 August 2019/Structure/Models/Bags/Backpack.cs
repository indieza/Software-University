namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        private readonly List<string> items;

        public Backpack()
        {
            this.items = new List<string>();
        }

        public ICollection<string> Items => this.items.AsReadOnly();

        public void AddItem(string item)
        {
            this.items.Add(item);
        }
    }
}