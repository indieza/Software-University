namespace GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public List<T> Data { get; set; } = new List<T>();

        public void Add(T value)
        {
            this.Data.Add(value);
        }
    }
}