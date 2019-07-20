namespace SoftUniRestaurant.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OutputMessages
    {
        public const string AddFood = "Added {0} ({1}) with price {2:f2} to the pool";

        public const string AddDrink = "Added {0} ({1}) to the drink pool";

        public const string AddTable = "Added table number {0} in the restaurant";

        public const string NoTable = "No available table for {0} people";

        public const string FindTable = "Table {0} has been reserved for {1} people";

        public const string TableDoesNotExist = "Could not find table with {0}";

        public const string FoodDoesNotExist = "No {0} in the menu";

        public const string TableOrderedFood = "Table {0} ordered {1}";

        public const string DrinkDoesNotExist = "There is no {0} {1} available";

        public const string TableOrderedDrink = "Table {0} ordered {1} {2}";

        public const string TotalIncome = "Total income: {0:f2}lv";
    }
}