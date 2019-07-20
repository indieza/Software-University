namespace SoftUniRestaurant.Models.Drinks.Contracts
{
    public interface IDrink
    {
        string Name { get; }

        int ServingSize { get; }

        decimal Price { get; }

        string Brand { get; }
    }
}