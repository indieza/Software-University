namespace _03.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private IList<T> data;

        public Stack()
        {
            this.Data = new List<T>();
        }

        public IList<T> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public void Push(T number)
        {
            this.data.Add(number);
        }

        public void Pop()
        {
            if (this.data.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            this.data.RemoveAt(this.data.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}