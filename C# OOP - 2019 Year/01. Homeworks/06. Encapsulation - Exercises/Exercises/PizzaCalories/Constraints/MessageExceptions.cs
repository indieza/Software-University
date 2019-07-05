namespace PizzaCalories.Constraints
{
    public class MessageExceptions
    {
        public const string InvalidPizzaNameLength = "Pizza name should be between 1 and 15 symbols.";

        public const string InvalidToppingsCount = "Number of toppings should be in range [0..10].";

        public const string InvalidToppingType = "Cannot place {0} on top of your pizza.";

        public const string IncalidToppingWeight = "{0} weight should be in the range [1..50].";

        public const string InvalidTypeOfDough = "Invalid type of dough.";

        public const string InvalidDoughWeight = "Dough weight should be in the range [1..200].";
    }
}