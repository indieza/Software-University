namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string favouriteFood, string name)
        {
            this.FavouriteFood = favouriteFood;
            this.Name = name;
        }

        public string FavouriteFood
        {
            get => this.favouriteFood;
            private set => this.favouriteFood = value;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}