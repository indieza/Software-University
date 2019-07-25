namespace Telecom
{
    using System;
    using System.Collections.Generic;

    public class Phone
    {
        private string make;
        private string model;
        private Dictionary<string, string> phonebook;

        public Phone(string make, string model)
        {
            this.Make = make;
            this.Model = model;

            this.phonebook = new Dictionary<string, string>();
        }

        public string Make
        {
            get => this.make;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid {nameof(this.Make)}!");
                }

                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid {nameof(this.Model)}!");
                }

                this.model = value;
            }
        }

        public int Count => this.phonebook.Count;

        public void AddContact(string name, string phone)
        {
            if (this.phonebook.ContainsKey(name))
            {
                throw new InvalidOperationException("Person already exists!");
            }

            this.phonebook.Add(name, phone);
        }

        public string Call(string name)
        {
            if (!this.phonebook.ContainsKey(name))
            {
                throw new InvalidOperationException("Person doesn't exists!");
            }

            var number = this.phonebook[name];

            return $"Calling {name} - {number}...";
        }
    }
}