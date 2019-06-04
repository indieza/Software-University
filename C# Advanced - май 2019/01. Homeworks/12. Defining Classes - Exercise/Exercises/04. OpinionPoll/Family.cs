using System.Reflection.Metadata.Ecma335;

namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> member = new List<Person>();

        public List<Person> Member
        {
            get => this.member;
            set => this.member = value;
        }

        public void AddMember(Person person)
        {
            member.Add(person);
        }

        public Person GetOldestMember()
        {
            var oldestPerson = member.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }

        public List<Person> GetMemberMoreThan30()
        {
            List<Person> oldestPerson = member.OrderBy(x => x.Name).Where(x => x.Age > 30).ToList<Person>();
            return oldestPerson;
        }
    }
}