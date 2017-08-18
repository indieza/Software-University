using System.Collections.Generic;

public abstract class Weapon
{
    private readonly List<Gem> sockets;

    private readonly Rarity Rarity;

    protected Weapon(Rarity rarity, string name, int minDamage, int maxDamage, int numberOfSockets)
    {
        this.Rarity = rarity;
        this.Name = name;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.NumberOfSockets = numberOfSockets;
        this.sockets = new List<Gem>(new Gem[numberOfSockets]);
        this.SetRarity();
    }

    public string Name { get; set; }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Vitality { get; set; }

    public int MinDamage { get; set; }

    public int MaxDamage { get; set; }

    public int NumberOfSockets { get; set; }

    public void AddGem(int index, Gem gem)
    {
        if (this.NumberOfSockets - 1 >= index)
        {
            this.sockets[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        if (this.NumberOfSockets - 1 >= index && this.sockets[index] != null)
        {
            this.sockets[index] = null;
        }
    }

    public void CalculateStats()
    {
        foreach (var gem in this.sockets)
        {
            if (gem != null)
            {
                this.Strength += gem.Strength;
                this.Agility += gem.Agility;
                this.Vitality += gem.Vitality;
                this.MinDamage += (gem.Strength * 2) + gem.Agility;
                this.MaxDamage += (gem.Strength * 3) + gem.Agility * 4;
            }
        }
    }

    public override string ToString()
    {
        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }

    private void SetRarity()
    {
        var statRarity = (int)(this.Rarity);
        this.MinDamage *= statRarity;
        this.MaxDamage *= statRarity;
    }
}