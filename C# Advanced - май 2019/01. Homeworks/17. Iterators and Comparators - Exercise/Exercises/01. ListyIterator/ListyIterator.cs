using System.Collections;

namespace _01.ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListyIterator<T>
    {

        public ListyIterator(params T[] data)
        {
            this.Data = data.ToList();
        }

        private List<T> Data { get;}

        public int Index { get; set; } = 0;

        public void Create(params T[] elements)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                this.Data.Add(elements[i]);
            }
        }

        public bool Move()
        {
            if (HasNext())
            {
                Index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return Index+1 < this.Data.Count;
        }

        public void Print()
        {
            if (this.Data.Count!=0)
            {
                Console.WriteLine(this.Data[Index]);
            }
            else
            {
                Console.WriteLine($"Invalid Operation!");
            }
        }
    }
}
