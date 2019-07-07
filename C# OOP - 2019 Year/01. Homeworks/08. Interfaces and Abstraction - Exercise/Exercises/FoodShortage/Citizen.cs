namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public string Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public string Birthdate
        {
            get => this.birthdate;
            private set => this.birthdate = value;
        }

        public int Food
        {
            get => this.food;
            private set => this.food = value;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}