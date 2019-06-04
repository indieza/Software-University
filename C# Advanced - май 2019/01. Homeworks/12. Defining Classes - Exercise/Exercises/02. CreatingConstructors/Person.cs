namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        

        public string Name
        {
            get=>this.name;
            set=>this.name=value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(int age) : this()
        {
            this.Age = age;
        }

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
    }
}