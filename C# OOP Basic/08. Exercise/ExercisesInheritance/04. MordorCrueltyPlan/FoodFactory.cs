public class FoodFactory
{
    public static Food ProduceFood(string food)
    {
        switch (food.ToLowerInvariant())
        {
            case "lembas":
                return new Lembas();

            case "cram":
                return new Cram();

            case "apple":
                return new Apple();

            case "melon":
                return new Melon();

            case "honeycake":
                return new HoneyCake();

            case "mushrooms":
                return new Mushrooms();

            default:
                return new UnknownFood();
        }
    }
}