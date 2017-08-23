using System.Collections.Generic;

public interface IHero
{
    string Name { get; }

    long Strength { get; }

    long Agility { get; }

    long Intelligence { get; }

    long HitPoints { get; }

    long Damage { get; }

    long PrimaryStats { get; }

    long SecondaryStats { get; }

    ICollection<IItem> Items { get; }

    void AddItem(IItem item);

    void AddRecipe(IRecipe recipe);
}