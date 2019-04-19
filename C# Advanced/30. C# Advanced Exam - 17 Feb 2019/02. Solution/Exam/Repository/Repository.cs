using System.Collections.Generic;

namespace Repository
{
    public class Repository
    {
        private readonly Dictionary<int, Person> data;
        private int id;
        private int count;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
            set
            {
                this.count = data.Count;
            }
        }

        public bool Update(int v, Person newPerson)
        {
            bool isUpdated = false;

            if (this.data.ContainsKey(v))
            {
                this.data[v] = new Person(newPerson.Name, newPerson.Age, newPerson.Birthdate);
                isUpdated = true;
            }

            return isUpdated;
        }

        public bool Delete(int v)
        {
            bool isDeleted = false;

            if (this.data.ContainsKey(v))
            {
                this.data.Remove(v);
                isDeleted = true;
            }

            return isDeleted;
        }

        public void Add(Person person)
        {
            this.data.Add(this.id, new Person(person.Name, person.Age, person.Birthdate));
            this.id++;
        }

        public Person Get(int n)
        {
            return this.data[n];
        }
    }
}