using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class InventoryTests
{
    private IInventory sut;

    [SetUp]
    public void TestInitialize()
    {
        this.sut = new HeroInventory();
    }

    [Test]
    public void NewInventoryStatsAreZero()
    {
        this.sut = new HeroInventory();

        long totalStatsBonus = this.sut.TotalAgilityBonus
                             + this.sut.TotalStrengthBonus
                             + this.sut.TotalIntelligenceBonus
                             + this.sut.TotalHitPointsBonus
                             + this.sut.TotalDamageBonus;

        Assert.AreEqual(0, totalStatsBonus);
    }

    [Test]
    public void GetBonusFromCommonItem()
    {
        IItem item = new CommonItem("TestItem", 1, 1, 1, 1, 1);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(1, this.sut.TotalAgilityBonus);
        Assert.AreEqual(1, this.sut.TotalDamageBonus);
        Assert.AreEqual(1, this.sut.TotalHitPointsBonus);
        Assert.AreEqual(1, this.sut.TotalIntelligenceBonus);
        Assert.AreEqual(1, this.sut.TotalStrengthBonus);
    }

    [Test]
    public void CreatingNewHeroInventoryIsSuccessful()
    {
        this.sut = new HeroInventory();

        Assert.Pass();
    }

    [Test]
    public void AddCommonItemIsSuccessful()
    {
        IItem item = new CommonItemMock("Axe", 10, 12, 13, 14, 15);

        this.sut.AddCommonItem(item);

        Assert.Pass();
    }

    [Test]
    public void AddingCommonItemsChangesTotalDamage()
    {
        IItem item1 = new CommonItemMock("Axe", 11, 12, 13, 14, 15);
        IItem item2 = new CommonItemMock("Fork", 31, 32, 33, 34, 35);

        this.sut.AddCommonItem(item1);
        this.sut.AddCommonItem(item2);

        Assert.AreEqual(50, this.sut.TotalDamageBonus);
    }

    [Test]
    public void AddCommonItemChangesStats()
    {
        IItem item = new CommonItemMock("Axe", 10, 10, 10, 10, 10);

        this.sut.AddCommonItem(item);
        long totalStatsBonus = this.sut.TotalAgilityBonus
                             + this.sut.TotalStrengthBonus
                             + this.sut.TotalIntelligenceBonus
                             + this.sut.TotalHitPointsBonus
                             + this.sut.TotalDamageBonus;

        Assert.AreEqual(50, totalStatsBonus);
    }

    [Test]
    public void AddCommonItemChangesDamage()
    {
        IItem item = new CommonItemMock("Axe", 10, 10, 10, 10, 9000);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(9000, this.sut.TotalDamageBonus);
    }

    [Test]
    public void AddCommonItemChangesHp()
    {
        IItem item = new CommonItemMock("Axe", 10, 10, 10, 800, 10);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(800, this.sut.TotalHitPointsBonus);
    }

    [Test]
    public void RecipeCompletionChangesStats()
    {
        string[] recipeComponents = new string[] { "Axe", "Shield" };
        IRecipe recipe = new RecipeItemMock("MegaWeapon", 100, 100, 100, 100, 100, recipeComponents);
        IItem axe = new CommonItemMock("Axe", 10, 10, 10, 10, 10);
        IItem shield = new CommonItemMock("Shield", 20, 20, 20, 20, 20);

        this.sut.AddCommonItem(axe);
        this.sut.AddCommonItem(shield);
        this.sut.AddRecipeItem(recipe);
        long totalStatsBonus = this.sut.TotalAgilityBonus
                     + this.sut.TotalStrengthBonus
                     + this.sut.TotalIntelligenceBonus
                     + this.sut.TotalHitPointsBonus
                     + this.sut.TotalDamageBonus;

        Assert.AreEqual(500, totalStatsBonus);
    }

    [Test]
    public void ChainingRecipes()
    {
        string[] recipeComponents1 = new string[] { "BootsOfSpeed" };
        IRecipe recipe1 = new RecipeItemMock("BootsOfTravell", 100, 100, 100, 100, 100, recipeComponents1);
        IItem boots = new CommonItemMock("BootsOfSpeed", 10, 10, 10, 10, 10);

        string[] recipeComponents2 = new string[] { "BootsOfTravell" };
        IRecipe recipe2 = new RecipeItemMock("BootsOfTravell2", 200, 200, 200, 200, 200, recipeComponents2);

        this.sut.AddCommonItem(boots);
        this.sut.AddRecipeItem(recipe1);
        this.sut.AddRecipeItem(recipe2);
        long totalStatsBonus = this.sut.TotalAgilityBonus
                     + this.sut.TotalStrengthBonus
                     + this.sut.TotalIntelligenceBonus
                     + this.sut.TotalHitPointsBonus
                     + this.sut.TotalDamageBonus;

        Assert.AreEqual(1000, totalStatsBonus);
    }

    [Test]
    public void AddingNullItemThrowsException()
    {
        IItem item = null;

        Assert.Throws<NullReferenceException>(() => this.sut.AddCommonItem(item));
    }

    [Test]
    public void AddingNullRecipeThrowsException()
    {
        IRecipe recipe = null;

        Assert.Throws<NullReferenceException>(() => this.sut.AddRecipeItem(recipe));
    }

    [Test]
    public void AddItemChangesTotalStregth()
    {
        var item = new CommonItemMock("Knife", 50, 10, 0, 0, 30);
        var item1 = new CommonItemMock("Hammer", 5, 10, 0, 0, 30);

        this.sut.AddCommonItem(item);
        this.sut.AddCommonItem(item1);

        Assert.AreEqual(55, this.sut.TotalStrengthBonus);
    }

    [Test]
    public void DuplicatingRecipeThrowsException()
    {
        string[] recipeComponents1 = new string[] { "BootsOfSpeed" };
        IRecipe recipe1 = new RecipeItemMock("BootsOfTravell", 100, 100, 100, 100, 100, recipeComponents1);

        this.sut.AddRecipeItem(recipe1);

        Assert.Throws<ArgumentException>(() => this.sut.AddRecipeItem(recipe1));
    }

    [Test]
    public void DuplicatingCommonItemThrowsException()
    {
        IItem item = new CommonItemMock("BootsOfTravell", 100, 100, 100, 100, 100);

        this.sut.AddCommonItem(item);

        Assert.Throws<ArgumentException>(() => this.sut.AddCommonItem(item));
    }

    [Test]
    public void CompleteRecipeForNewItem()
    {
        IItem relic = new CommonItemMock("SacredRelic", 0, 0, 0, 0, 60);
        string[] recipeComponents = new string[] { "SacredRelic", "RadianceRecipe" };
        IRecipe recipe = new RecipeItemMock("Radiance", 0, 0, 0, 0, 80, recipeComponents);
        IItem radianceRecipe = new CommonItemMock("RadianceRecipe", 0, 0, 0, 0, 0);

        this.sut.AddCommonItem(relic);
        this.sut.AddRecipeItem(recipe);
        this.sut.AddCommonItem(radianceRecipe);

        Assert.AreEqual(80, this.sut.TotalDamageBonus);
    }
}