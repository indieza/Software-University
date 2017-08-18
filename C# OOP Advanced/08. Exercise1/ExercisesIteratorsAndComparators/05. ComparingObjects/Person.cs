namespace _05.ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Town
        {
            get { return this.town; }
            set { this.town = value; }
        }

        public int CompareTo(Person other)
        {
            if (string.Compare(this.Name, other.Name, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
            }

            if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            return string.Compare(this.Town, other.Town, StringComparison.Ordinal);
        }
    }
}