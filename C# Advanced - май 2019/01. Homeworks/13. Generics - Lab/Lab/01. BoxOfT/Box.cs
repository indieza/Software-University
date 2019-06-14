namespace BoxOfT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Box<T>
    {
        public Box()
        {
            this.Data = new List<T>();
        }

        public List<T> Data { get; set; }

        public int Count => this.Data.Count;

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public T Remove()
        {
            T element = this.Data[this.Data.Count - 1];
            this.Data.RemoveAt(this.Data.Count - 1);
            return element;
        }
    }
}