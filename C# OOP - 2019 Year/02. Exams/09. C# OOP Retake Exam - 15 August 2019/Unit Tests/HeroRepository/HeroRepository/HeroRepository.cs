using System;
using System.Collections.Generic;
using System.Linq;

public class HeroRepository
{
    private readonly List<Hero> data;

    public HeroRepository()
    {
        this.data = new List<Hero>();
    }

    public string Create(Hero hero)
    {
        if (hero == null)
        {
            throw new ArgumentNullException(nameof(hero), "Hero is null");
        }

        if (this.data.Any(h => h.Name == hero.Name))
        {
            throw new InvalidOperationException($"Hero with name {hero.Name} already exists");
        }

        this.data.Add(hero);
        return $"Successfully added hero {hero.Name} with level {hero.Level}";
    }

    public bool Remove(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be null");
        }

        Hero hero = this.data.FirstOrDefault(h => h.Name == name);
        bool isRemoved = this.data.Remove(hero);
        return isRemoved;
    }

    public Hero GetHeroWithHighestLevel()
    {
        Hero hero = this.data.OrderByDescending(h => h.Level).ToArray()[0];
        return hero;
    }

    public Hero GetHero(string name)
    {
        Hero hero = this.data.FirstOrDefault(h => h.Name == name);
        return hero;
    }

    public IReadOnlyCollection<Hero> Heroes => this.data.AsReadOnly();
}