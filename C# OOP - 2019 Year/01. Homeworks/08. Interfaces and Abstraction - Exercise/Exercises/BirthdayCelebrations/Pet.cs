namespace BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        private string name;
        private string bithdate;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public string Birthdate
        {
            get => this.bithdate;
            private set => this.bithdate = value;
        }
    }
}