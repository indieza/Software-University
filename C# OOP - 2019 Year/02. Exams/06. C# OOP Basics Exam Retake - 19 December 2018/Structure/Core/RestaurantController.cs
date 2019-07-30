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
        private decimal income;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.income = 0;
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
                result = string.Format(OutputMessages.FoodMade,
                    name,
                    food.GetType().Name,
                    food.Price);
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
                result = string.Format(OutputMessages.DrinkMade,
                    name,
                    drink.Brand);
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

            string result = string.Empty;

            if (table != null)
            {
                this.tables.Add(table);
                result = string.Format(OutputMessages.TableMade, table.TableNumber);
            }

            return result;
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable targetTable = this.tables
                .FirstOrDefault(t => t.Capacity >= numberOfPeople &&
                t.IsReserved == false);

            if (targetTable == null)
            {
                return string.Format(OutputMessages.NoAvailableTable, numberOfPeople);
            }
            else
            {
                targetTable.Reserve(numberOfPeople);

                return string.Format(OutputMessages.TableReserved,
                    targetTable.TableNumber,
                    targetTable.NumberOfPeople);
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable targetTable = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            if (targetTable == null)
            {
                return string.Format(OutputMessages.CouldNotFindTable, tableNumber);
            }

            IFood targetFood = this.menu.FirstOrDefault(f => f.Name == foodName);

            if (targetFood == null)
            {
                return string.Format(OutputMessages.NoFoodInMenu, foodName);
            }

            targetTable.OrderFood(targetFood);

            return string.Format(OutputMessages.FoodOrdered, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable targetTable = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            if (targetTable == null)
            {
                return string.Format(OutputMessages.CouldNotFindTable, tableNumber);
            }

            IDrink targetDrink = this.drinks.FirstOrDefault(d => d.Name == drinkName &&
                d.Brand == drinkBrand);

            if (targetDrink == null)
            {
                return string.Format(OutputMessages.NoDrinkInMenu, drinkName, drinkBrand);
            }

            targetTable.OrderDrink(targetDrink);

            return string.Format(OutputMessages.DrinkOrdered,
                tableNumber,
                drinkName,
                drinkBrand);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.TableInformation, tableNumber));
            sb.AppendLine(string.Format(OutputMessages.BillInformation, table.GetBill()));
            this.income += table.GetBill();
            table.Clear();

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
            return string.Format(OutputMessages.TotalIncome, this.income);
        }
    }
}