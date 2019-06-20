using System;
using System.Linq;

namespace _03.Stack
{
    using System.Collections;
    using System.Collections.Generic;

    class CustomStack<T>:IEnumerable<T>
    {
        public CustomStack()
        {
            this.Data = new Stack<T>();
        }

        private Stack<T> Data { get; }

        public void Add(T value)
        {
           this.Data.Push(value);
        }

        public void Remove()
        {
            if (this.Data.Any())
            {
                this.Data.Pop();
            }
            else
            {
                Console.WriteLine($"No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var data in Data)
            {
                    yield return data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
