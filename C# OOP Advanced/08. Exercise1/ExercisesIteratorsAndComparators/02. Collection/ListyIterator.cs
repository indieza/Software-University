namespace _02.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> data;
        private int currentIndex;

        public ListyIterator()
        {
            this.data = new List<T>();
            this.CurrentIndex = 0;
        }

        public ListyIterator(IList<T> items)
        {
            this.data = items;
        }

        public IList<T> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set { this.currentIndex = value; }
        }

        public bool Move()
        {
            if (this.data.Count - 1 > this.currentIndex)
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public T Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.data[this.CurrentIndex];
        }

        public IEnumerable<T> PrintAll()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            foreach (var item in this.data)
            {
                yield return item;
            }
        }

        public bool HasNext()
        {
            if (this.data.Count - 1 > this.currentIndex)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}