namespace FoodShortage
{
    public interface IBuyer
    {
        string Name { get; }

        int Age { get; }

        void BuyFood();

        int Food { get; }
    }
}