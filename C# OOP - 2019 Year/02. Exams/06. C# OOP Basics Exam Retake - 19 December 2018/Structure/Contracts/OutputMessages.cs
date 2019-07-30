namespace SoftUniRestaurant.Contracts
{
    public class OutputMessages
    {
        public const string FoodMade = "Added {0} ({1}) with price {2:F2} to the pool";

        public const string DrinkMade = "Added {0} ({1}) to the drink pool";

        public const string TableMade = "Added table number {0} in the restaurant";

        public const string NoAvailableTable = "No available table for {0} people";

        public const string TableReserved = "Table {0} has been reserved for {1} people";

        public const string CouldNotFindTable = "Could not find table with {0}";

        public const string NoFoodInMenu = "No {0} in the menu";

        public const string FoodOrdered = "Table {0} ordered {1}";

        public const string NoDrinkInMenu = "There is no {0} {1} available";

        public const string DrinkOrdered = "Table {0} ordered {1} {2}";

        public const string TableInformation = "Table: {0}";

        public const string BillInformation = "Bill: {0:F2}";

        public const string TotalIncome = "Total income: {0:F2}lv";
    }
}