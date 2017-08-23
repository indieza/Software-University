using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    private Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        // Possible bug
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });
            this.heroes.Add(hero.Name, hero);

            result = string.Format(Constants.HeroCreateMessage, heroType, hero.Name);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItem(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.heroes[heroName].AddItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string Quit(object argsList)
    {
        StringBuilder sb = new StringBuilder();

        int counter = 1;

        var orderedHeroes = this.heroes
            .OrderByDescending(h => h.Value.PrimaryStats)
            .ThenByDescending(h => h.Value.SecondaryStats)
            .ToDictionary(x => x.Key, y => y.Value);

        foreach (var hero in orderedHeroes)
        {
            sb.AppendLine($"{counter++}. {hero.Value.GetType().Name}: {hero.Key}");
            sb.AppendLine($"###HitPoints: {hero.Value.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Value.Damage}");
            sb.AppendLine($"###Strength: {hero.Value.Strength}");
            sb.AppendLine($"###Agility: {hero.Value.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Value.Intelligence}");

            if (hero.Value.Items.Count == 0)
            {
                sb.AppendLine($"###Items: None");
            }
            else
            {
                sb.Append($"###Items: ");
                var items = hero.Value.Items.Select(i => i.Name).ToList();
                sb.AppendLine(string.Join(", ", items));
            }
        }

        return sb.ToString().Trim();
    }

    public string AddRecipe(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        List<string> requiredItems = arguments.Skip(7).ToList();

        IRecipe newRecipe = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);
        this.heroes[heroName].AddRecipe(newRecipe);

        //Possible bug
        result = string.Format(Constants.RecipeCreatedMessage, newRecipe.Name, heroName);
        return result;
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    private string CreateGame()
    {
        StringBuilder result = new StringBuilder();

        foreach (var hero in heroes)
        {
            result.AppendLine(hero.Key);
        }

        return result.ToString();
    }

    //Само Батман знае как работи това
    //public void GenerateResult()
    //{
    //    const string PropName = "_connectionString";
    //
    //    var type = typeof(HeroCommand);
    //
    //    FieldInfo fieldInfo = null;
    //    PropertyInfo propertyInfo = null;
    //    while (fieldInfo == null && propertyInfo == null && type != null)
    //    {
    //        fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | //BindingFlags.Instance);
    //        if (fieldInfo == null)
    //        {
    //            propertyInfo = type.GetProperty(PropName,
    //                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        }
    //
    //        type = type.BaseType;
    //    }
    //}
}