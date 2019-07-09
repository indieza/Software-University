namespace CollectionHierarchy
{
    using System.Collections.Generic;

    public class Collection : IAddCollection
    {
        public Collection()
        {
            Data = new List<string>();
        }

        public List<string> Data { get; }

        public virtual int Add(string item)
        {
            this.Data.Insert(0, item);
            return 0;
        }
    }
}