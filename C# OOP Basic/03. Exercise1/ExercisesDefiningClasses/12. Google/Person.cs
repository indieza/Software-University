using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private List<Company> companies;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Children> childrens;
    private List<Car> cars;

    public Person(string name)
    {
        this.name = name;
        this.companies = new List<Company>();
        this.pokemons = new List<Pokemon>();
        this.parents = new List<Parent>();
        this.childrens = new List<Children>();
        this.cars = new List<Car>();
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public List<Company> Companies
    {
        get { return this.companies; }
        set { this.companies = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public List<Parent> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Children> Children
    {
        get { return this.childrens; }
        set { this.childrens = value; }
    }

    public List<Car> Car
    {
        get { return this.cars; }
        set { this.cars = value; }
    }

    public override string ToString()
    {
        string result = string.Empty;
        result += $"{this.name}\n";
        result += "Company:\n";
        result += this.companies.Count == 0 ? string.Empty : string.Join("\n", this.companies) + "\n";
        result += "Car:\n";
        result += this.cars.Count == 0 ? string.Empty : string.Join("\n", this.cars) + "\n";
        result += "Pokemon:\n";
        result += this.pokemons.Count == 0 ? string.Empty : string.Join("\n", this.pokemons) + "\n";
        result += "Parents:\n";
        result += this.parents.Count == 0 ? string.Empty : string.Join("\n", this.parents) + "\n";
        result += "Children:";
        result += this.childrens.Count == 0 ? string.Empty : "\n" + string.Join("\n", this.childrens);
        return result;
    }
}