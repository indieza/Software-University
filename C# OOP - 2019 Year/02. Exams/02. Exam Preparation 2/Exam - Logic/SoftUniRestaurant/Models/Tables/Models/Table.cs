using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooPark.Models.Tables.Models
{
    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; }

        public decimal Price => this.foodOrders.Sum(f => f.Price)
            + this.drinkOrders.Sum(f => f.Price)
            + this.PricePerPerson * this.NumberOfPeople;

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public decimal GetBill()
        {
            throw new NotImplementedException();
        }

        public string GetFreeTableInfo()
        {
            throw new NotImplementedException();
        }

        public string GetOccupiedTableInfo()
        {
            throw new NotImplementedException();
        }

        public void OrderDrink(IDrink drink)
        {
            throw new NotImplementedException();
        }

        public void OrderFood(IFood food)
        {
            throw new NotImplementedException();
        }

        public void Reserve(int numberOfPeople)
        {
            throw new NotImplementedException();
        }
    }
}