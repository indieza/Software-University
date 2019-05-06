namespace SoftUniRestaurant.Core
{
    using System;

    public class RestaurantController
    {
        public string AddFood(string type, string name, decimal price)
        {
            throw new NotImplementedException();
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            throw new NotImplementedException();
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            throw new NotImplementedException();
        }

        public string ReserveTable(int numberOfPeople)
        {
            throw new NotImplementedException();
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            throw new NotImplementedException();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            throw new NotImplementedException();
        }

        public string LeaveTable(int tableNumber)
        {
            throw new NotImplementedException();
        }

        public string GetFreeTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetOccupiedTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
