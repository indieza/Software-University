using NUnit.Framework;
using System;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero1;
    private Hero hero2;
    private Hero hero3;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        this.hero1 = new Hero("Name1", 1);
        this.hero2 = new Hero("Name2", 2);
        this.hero3 = new Hero("Name3", 3);
        this.heroRepository = new HeroRepository();
    }

    [Test]
    public void Test_Constructure()
    {
        Assert.AreEqual("Name1", this.hero1.Name);
        Assert.AreEqual(1, this.hero1.Level);
        Assert.AreEqual(0, this.heroRepository.Heroes.Count);
    }

    [Test]
    public void Test_Create_Null_Hero()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(null));
    }

    [Test]
    public void Test_Create_Existing_Hero()
    {
        this.heroRepository.Create(this.hero1);
        Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(this.hero1));
    }

    [Test]
    public void Test_Create_Hero()
    {
        Assert.AreEqual($"Successfully added hero {this.hero1.Name} with level {this.hero1.Level}",
            this.heroRepository.Create(this.hero1));
        Assert.AreEqual(1, this.heroRepository.Heroes.Count);
    }

    [Test]
    public void Test_Remove_Null_Name()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(null));
    }

    [Test]
    public void Test_Remove_Name_True()
    {
        this.heroRepository.Create(this.hero1);
        Assert.AreEqual(true, this.heroRepository.Remove("Name1"));
    }

    [Test]
    public void Test_Remove_Name_False()
    {
        this.heroRepository.Create(this.hero1);
        Assert.AreEqual(false, this.heroRepository.Remove("Name2"));
    }

    [Test]
    public void Test_Remove()
    {
        this.heroRepository.Create(this.hero1);
        this.heroRepository.Create(this.hero2);
        this.heroRepository.Create(this.hero3);
        this.heroRepository.Remove("Name1");
        Assert.AreEqual(2, this.heroRepository.Heroes.Count);
    }

    [Test]
    public void Test_Get_Hero_With_Highest_Level()
    {
        this.heroRepository.Create(this.hero1);
        this.heroRepository.Create(this.hero2);
        this.heroRepository.Create(this.hero3);
        Assert.AreEqual(this.hero3, this.heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void Test_Get_Hero()
    {
        this.heroRepository.Create(this.hero1);
        this.heroRepository.Create(this.hero2);
        this.heroRepository.Create(this.hero3);
        Assert.AreEqual(this.hero3, this.heroRepository.GetHero("Name3"));
    }

    [Test]
    public void Test_Get_Null_Hero()
    {
        this.heroRepository.Create(this.hero1);
        this.heroRepository.Create(this.hero2);
        this.heroRepository.Create(this.hero3);
        Assert.AreEqual(null, this.heroRepository.GetHero("Name4"));
    }
}