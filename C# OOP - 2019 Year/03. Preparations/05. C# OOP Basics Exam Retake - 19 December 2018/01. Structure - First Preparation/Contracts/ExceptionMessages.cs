namespace SoftUniRestaurant.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionMessages
    {
        public const string NullName = "Name cannot be null or white space!";

        public const string NegativeServingSize = "Serving size cannot be less or equal to zero";

        public const string NegativePrice = "Price cannot be less or equal to zero!";

        public const string NullBrandName = "Brand cannot be null or white space!";

        public const string NegativeTableCapacity = "Capacity has to be greater than 0";

        public const string NegativeNumberOfPeople = "Cannot place zero or less people!";
    }
}