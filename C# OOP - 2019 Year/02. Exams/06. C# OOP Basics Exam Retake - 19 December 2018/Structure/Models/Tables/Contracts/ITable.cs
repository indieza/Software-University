using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using System.Collections.Generic;

namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public interface ITable
    {
        IReadOnlyCollection<IFood> FoodOrders { get; }

        IReadOnlyCollection<IDrink> DrinkOrders { get; }

        int TableNumber { get; }

        int Capacity { get; }

        int NumberOfPeople { get; set; }

        decimal PricePerPerson { get; }

        bool IsReserved { get; set; }

        decimal Price { get; }

        void Reserve(int numberOfPeople);

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();

        string GetOccupiedTableInfo();
    }
}