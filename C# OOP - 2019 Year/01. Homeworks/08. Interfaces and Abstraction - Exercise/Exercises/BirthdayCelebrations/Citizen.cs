namespace BirthdayCelebrations
{
    public class Citizen : Entered, IBirthable
    {
        private string name;
        private int age;
        private string bithdate;

        public Citizen(string name, int age, string id, string birthdate)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            private set => this.age = value;
        }

        public string Birthdate
        {
            get => this.bithdate;
            private set => this.bithdate = value;
        }
    }
}