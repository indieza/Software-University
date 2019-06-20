using System;

namespace _07.EqualityLogic
{
    public class Person:IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.Name == person.Name && this.Age == person.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode()+this.Age.GetHashCode();
        }

        public int CompareTo(Person other)
        {
            return this.Name.CompareTo(other.Name) == 0 
                ? this.Age - other.Age 
                : this.Name.CompareTo(other.Name);
        }
    }
}
