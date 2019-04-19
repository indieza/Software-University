using System;

namespace Repository
{
    public class Person
    {
        private string name;
        private int age;
        private DateTime birthdate;

        public Person(string name, int age, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return this.birthdate;
            }
            set
            {
                this.birthdate = value;
            }
        }
    }
}