using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private IList<CoffeeType> coffeesSold;
    private int totalMoney;

    public CoffeeMachine()
    {
        this.CoffeesSold = new List<CoffeeType>();
        this.totalMoney = 0;
    }

    public IList<CoffeeType> CoffeesSold
    {
        get { return this.coffeesSold; }
        set { this.coffeesSold = value; }
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        int price = (int)coffeePrice;
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);
        if (this.totalMoney >= price)
        {
            this.CoffeesSold.Add(coffeeType);
        }
    }

    public void InsertCoin(string coin)
    {
        Coin coins = (Coin)Enum.Parse(typeof(Coin), coin);
        this.totalMoney += (int)coins;
    }
}