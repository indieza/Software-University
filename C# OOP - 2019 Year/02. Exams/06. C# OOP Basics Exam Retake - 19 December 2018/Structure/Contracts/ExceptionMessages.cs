namespace SoftUniRestaurant.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionMessages
    {
        public const string NullFoodName = "Name cannot be null or white space!";

        public const string NegativeFoodServingSize = "Serving size cannot be less or equal to zero";

        public const string NegativeFoodPrice = "Price cannot be less or equal to zero!";

        public const string NullDrinkName = "Name cannot be null or white space!";

        public const string NegativeDrinkServingSize = "Serving size cannot be less or equal to zero";

        public const string NegativeDrinkPrice = "Price cannot be less or equal to zero";

        public const string NullDrinkBrand = "Brand cannot be null or white space!";

        public const string NegativeTableCapacity = "Capacity has to be greater than 0";

        public const string NegativeNumberOfPeopleForTable = "Cannot place zero or less people!";
    }
}