namespace Repository
{
    using System.Collections.Generic;
    using System.Linq;

    public class Repository
    {
        private Dictionary<int, Person> people;
        private int id;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.id = 0;
        }

        public int Count => this.people.Count();

        public void Add(Person person)
        {
            this.people.Add(this.id++, person);
        }

        public Person Get(int searchId)
        {
            return this.people[searchId];
        }

        public bool Update(int id, Person newPerson)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            this.people[id] = newPerson;
            return true;
        }

        public bool Delete(int id)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            this.people.Remove(id);
            return true;
        }
    }
}