namespace _05.ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name == other.Name && this.Age == other.Age && this.Town == other.Town)
            {
                return 0;
            }

            return -1;
        }
    }
}
