namespace PlayersAndMonsters
{
    public abstract class Hero
    {
        private string username;
        private int level;

        protected Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username
        {
            get => this.username;
            set => this.username = value;
        }

        public int Level
        {
            get => this.level;
            set => this.level = value;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}