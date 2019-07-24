namespace UnitTests
{
    using System;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = value;
        }

        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public void TestFirstName()
        {
            if (this.FirstName.Length <= 3)
            {
                throw new InvalidOperationException("Name should have at least 4 symbols length");
            }
        }

        public override string ToString()
        {
            return $"Hello my name is {this.FirstName} {this.LastName} and I am {this.Age} years old";
        }
    }
}