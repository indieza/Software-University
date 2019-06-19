namespace Heroes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            //Initialize the repository
            HeroRepository repository = new HeroRepository();
            //Initialize entity
            Item item = new Item(23, 35, 48);
            //Print Item
            Console.WriteLine(item);

            //Item:
            //    * Strength: 23
            //    * Ability: 35
            //    * Intelligence: 48

            //Initialize entity
            Hero hero = new Hero("Hero Name", 24, item);
            //Print Hero
            Console.WriteLine(hero);

            //Hero: Hero Name - 24lvl
            //Item:
            //    * Strength: 23
            //    * Ability: 35
            //    * Intelligence: 48

            //Add Hero
            repository.Add(hero);
            //Remove Hero
            repository.Remove("Hero Name");

            Item secondItem = new Item(100, 20, 13);
            Hero secondHero = new Hero("Second Hero Name", 125, secondItem);

            //Add Heroes
            repository.Add(hero);
            repository.Add(secondHero);

            Hero heroStrength = repository.GetHeroWithHighestStrength(); // Hero with name Second Hero
            Hero heroAbility = repository.GetHeroWithHighestAbility(); // Hero with name Hero Name
            Hero heroIntelligence = repository.GetHeroWithHighestIntelligence(); // Hero with name Hero

            Console.WriteLine(repository.Count); //2

            Console.WriteLine(repository);
            //Hero: Hero Name - 24lvl
            //Item:
            //*Strength: 23
            //    * Ability: 35
            //    * Intelligence: 48
            //Hero: Second Hero Name - 125lvl
            //Item:
            //    * Strength: 100
            //    * Ability: 20
            //    * Intelligence: 13
        }
    }
}
