namespace WildFarm.Factories
{
    using WildFarm.Models.Food;

    public class FoodFactory
    {
        public static Food CreateFood(string[] foodParams)
        {
            Food food = null;
            string foodType = foodParams[0];
            int quantity = int.Parse(foodParams[1]);

            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;

                case "Fruit":
                    food = new Fruit(quantity);
                    break;

                case "Meat":
                    food = new Meat(quantity);
                    break;

                case "Seeds":
                    food = new Seeds(quantity);
                    break;

                default:
                    break;
            }

            return food;
        }
    }
}