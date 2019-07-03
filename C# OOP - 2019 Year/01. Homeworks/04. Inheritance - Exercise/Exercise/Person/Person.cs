
namespace Person
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Person
    {
        private string name;
        private int age;

        protected Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name
        {
            get => this.name;

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }

                this.name = value;
            }

        }

        public virtual int Age
        {
            get => this.age;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                this.age = value;

            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(($"Name: {this.Name}, Age: {this.Age}"));

            return sb.ToString();
        }

    }
}