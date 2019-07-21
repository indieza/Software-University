namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Contracts;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Drinks.Models;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Foods.Models;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using SoftUniRestaurant.Models.Tables.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private readonly List<IFood> menu;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0m;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = null;

            switch (type)
            {
                case "Dessert":
                    food = new Dessert(name, price);
                    break;

                case "MainCourse":
                    food = new MainCourse(name, price);
                    break;

                case "Salad":
                    food = new Salad(name, price);
                    break;

                case "Soup":
                    food = new Soup(name, price);
                    break;

                default:
                    break;
            }

            string result = string.Empty;

            if (food != null)
            {
                this.menu.Add(food);
                result += string.Format(OutputMessages.AddFood, food.Name, food.GetType().Name, food.Price);
            }

            return result;
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = null;

            switch (type)
            {
                case "Alcohol":
                    drink = new Alcohol(name, servingSize, brand);
                    break;

                case "FuzzyDrink":
                    drink = new FuzzyDrink(name, servingSize, brand);
                    break;

                case "Juice":
                    drink = new Juice(name, servingSize, brand);
                    break;

                case "Water":
                    drink = new Water(name, servingSize, brand);
                    break;

                default:
                    break;
            }

            string result = string.Empty;

            if (drink != null)
            {
                this.drinks.Add(drink);
                result += string.Format(OutputMessages.AddDrink, drink.Name, drink.Brand);
            }

            return result;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            switch (type)
            {
                case "Inside":
                    table = new InsideTable(tableNumber, capacity);
                    break;

                case "Outside":
                    table = new OutsideTable(tableNumber, capacity);
                    break;

                default:
                    break;
            }

            this.tables.Add(table);
            return string.Format(OutputMessages.AddTable, table.TableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.NoTable, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);
                return string.Format(OutputMessages.FindTable, table.TableNumber, numberOfPeople);
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.TableDoesNotExist, tableNumber);
            }

            IFood food = this.menu.FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.FoodDoesNotExist, foodName);
            }

            table.OrderFood(food);
            return string.Format(OutputMessages.TableOrderedFood, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.TableDoesNotExist, tableNumber);
            }

            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return string.Format(OutputMessages.DrinkDoesNotExist, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return string.Format(OutputMessages.TableOrderedDrink, tableNumber, drinkName, drinkBrand);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.TableDoesNotExist, tableNumber);
            }

            decimal bill = table.GetBill();
            table.Clear();

            this.totalIncome += bill;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:F2}");

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ITable table in this.tables.Where(t => t.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ITable table in this.tables.Where(t => t.IsReserved == true))
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return string.Format(OutputMessages.TotalIncome, this.totalIncome);
        }
    }
}